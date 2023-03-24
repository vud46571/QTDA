    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using Newtonsoft.Json.Linq;

namespace DoAn.Areas.User.Controllers
{
    [Authorize]
    public class QuestController : Controller
    {
        private DoanNCEntities db = new DoanNCEntities();
        // GET: User/Quest
        public ActionResult Index(int id)
        {
            List<CauHoi> lst = db.CauHois.Where(x => x.MaDeThi == id).ToList();
            return View(lst);
        }
        public ActionResult DeThi(int id)
        {
            List<DeThi> lst1 = db.DeThis.Where(x =>x.id == id).ToList();
            return View(lst1);
        }
        [HttpPost]
        public ActionResult Index()
        {
            String QA = Request["QA"];
            QA += "";
            String ss = "" + Session["UserName"];
                int id_nd = Int32.Parse("" + Session["UserName"]);

            JObject json = JObject.Parse(QA);
            bool kt = true;
            foreach (var e in json)
            {
                int idCH = Int32.Parse(e.Key.ToString());
                String CauTl = e.Value.ToString();
                if (db.CauHois.Where(x => ((x.id == idCH)) && (x.DapAn == CauTl)) != null)
                    kt = true;
                else kt = false;
                CTKetQua CTKQ = new CTKetQua();
                CTKQ.MaCauHoi = idCH;
                CTKQ.MaThanhVien = id_nd;
                CTKQ.DaTl = kt;
                db.CTKetQuas.Add(CTKQ);
                db.SaveChanges();

            }
            String id_made = Request["id"];
            return RedirectToAction("Index", "DiemThi", new { id = id_made });
        }
    }
}