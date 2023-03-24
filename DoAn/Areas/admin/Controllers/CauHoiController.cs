using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Areas.admin.Controllers
{
    public class CauHoiController : Controller
    {
        private DoanNCEntities db = new DoanNCEntities();

        // GET: admin/CauHoi
        public ActionResult Index()
        {
            var cauHois = db.CauHois.Include(c => c.DeThi).Include(c => c.DoKho);
            return View(cauHois.ToList());
        }

        // GET: admin/CauHoi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            return View(cauHoi);
        }

        // GET: admin/CauHoi/Create
        public ActionResult Create()
        {
            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "id");
            ViewBag.Muc_do_kho = new SelectList(db.DoKhoes, "id", "TenMucDo");
            return View();
        }

        // POST: admin/CauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MaDeThi,DapAn,Cau_hoi,Dap_an_1,Dap_an_2,Dap_an_3,Dap_an_4,Ghi_chu,Muc_do_kho")] CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                db.CauHois.Add(cauHoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "id", cauHoi.MaDeThi);
            ViewBag.Muc_do_kho = new SelectList(db.DoKhoes, "id", "TenMucDo", cauHoi.Muc_do_kho);
            return View(cauHoi);
        }

        // GET: admin/CauHoi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "id", cauHoi.MaDeThi);
            ViewBag.Muc_do_kho = new SelectList(db.DoKhoes, "id", "TenMucDo", cauHoi.Muc_do_kho);
            return View(cauHoi);
        }

        // POST: admin/CauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MaDeThi,DapAn,Cau_hoi,Dap_an_1,Dap_an_2,Dap_an_3,Dap_an_4,Ghi_chu,Muc_do_kho")] CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cauHoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "id", cauHoi.MaDeThi);
            ViewBag.Muc_do_kho = new SelectList(db.DoKhoes, "id", "TenMucDo", cauHoi.Muc_do_kho);
            return View(cauHoi);
        }

        // GET: admin/CauHoi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            return View(cauHoi);
        }

        // POST: admin/CauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CauHoi cauHoi = db.CauHois.Find(id);
            db.CauHois.Remove(cauHoi);
            db.SaveChanges();
            return RedirectToAction("Index");
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
