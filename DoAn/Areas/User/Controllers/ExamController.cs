using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Areas.User.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private DoanNCEntities db = new DoanNCEntities();
        // GET: User/Exam
        public ActionResult Index()
        {
            List<DeThi> lst = db.DeThis.ToList();
            return View(lst);
        }
    }
}