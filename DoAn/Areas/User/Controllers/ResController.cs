using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Areas.User.Controllers
{

    public class ResController : Controller
    {
        // GET: User/Res
        private DoanNCEntities db = new DoanNCEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Username,Password,SDT,Diachi,Anh")] ThanhVien nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.ThanhViens.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("../../User/Login/Index");
            }
            return View(nguoidung);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}