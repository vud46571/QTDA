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
    public class KetQuaController : Controller
    {
        private DoanNCEntities db = new DoanNCEntities();

        // GET: admin/KetQua
        public ActionResult Index()
        {
            var ketQuas = db.KetQuas.Include(k => k.DeThi).Include(k => k.ThanhVien);
            return View(ketQuas.ToList());
        }

        // GET: admin/KetQua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // GET: admin/KetQua/Create
        public ActionResult Create()
        {
            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "ThoiGianThi");
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "id", "Username");
            return View();
        }

        // POST: admin/KetQua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThanhVien,MaDeThi,Diem")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.KetQuas.Add(ketQua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "ThoiGianThi", ketQua.MaDeThi);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "id", "Username", ketQua.MaThanhVien);
            return View(ketQua);
        }

        // GET: admin/KetQua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "ThoiGianThi", ketQua.MaDeThi);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "id", "Username", ketQua.MaThanhVien);
            return View(ketQua);
        }

        // POST: admin/KetQua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThanhVien,MaDeThi,Diem")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDeThi = new SelectList(db.DeThis, "id", "ThoiGianThi", ketQua.MaDeThi);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "id", "Username", ketQua.MaThanhVien);
            return View(ketQua);
        }

        // GET: admin/KetQua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // POST: admin/KetQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KetQua ketQua = db.KetQuas.Find(id);
            db.KetQuas.Remove(ketQua);
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
