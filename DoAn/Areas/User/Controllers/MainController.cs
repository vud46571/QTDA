using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DoAn.Areas.User.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        // GET: User/Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("../../User/LogIn/Index");
        }
    }
}