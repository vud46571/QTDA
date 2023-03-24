using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.User.Controllers
{
    [Authorize]
    public class AdmissionController : Controller
    {
        // GET: User/Admission
        public ActionResult Index()
        {
            return View();
        }
    }
}