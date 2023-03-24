using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using System.Web.Security;

namespace DoAn.Areas.User.Controllers
{
    public class LoginController : Controller
    {
        // GET: User/Login
        public ActionResult Index()
        {
            return View();
        }
    public int swapid(string Username)
        {
            DoanNCEntities db = new DoanNCEntities();
            List<ThanhVien> lst = db.ThanhViens.Where(x => (x.Username == Username)).ToList();
            int id = lst.First().id;
            return id;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(Model.DTO.UserModel user)
        {
            if (ModelState.IsValid)
            {
                bool isVal = Model.DAO.AccountDAO.checkLogin(user.Users, user.Passwords);
                if (isVal == true)
                {
                    string ReturnUrl = "";
                    int id = swapid(user.Users);
                    Session["UserName"] = "" + id;
                    FormsAuthentication.SetAuthCookie(user.Passwords, false);
                    if (Request.QueryString["ReturnUrl"] == null)
                        ReturnUrl = "~/User/Main/";
                    else ReturnUrl = Request.QueryString["ReturnUrl"].ToString();
                    return Redirect(ReturnUrl);
                }

                else
                {
                    // error
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View(user);
        }
    }
}