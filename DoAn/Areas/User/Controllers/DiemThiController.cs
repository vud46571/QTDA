using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Areas.User.Controllers
{
    public class DiemThiController : Controller
    {
        DoanNCEntities db = new DoanNCEntities();
        // GET: User/DiemThi
        public ActionResult TenND()
        {
            int idnd1 = Int32.Parse("" + Session["UserName"]);
            List<ThanhVien> lst = db.ThanhViens.Where(x => (x.id == idnd1)).ToList();
            String hoten = lst.First().HoTen.ToString();
            ViewBag.ht = hoten;
            return View();
        }
        public int xuly(int id)
        {
            int socau = 0;
            List<CauHoi> lst = db.CauHois.Where(x => (x.MaDeThi == id)).ToList();
            socau = lst.Count();
            return socau;
        }
        public ActionResult Index(int id)
        {
            int co = 0;
            int idnd = Int32.Parse("" + Session["UserName"]);
            List<CTKetQua> lst = db.CTKetQuas.Where((x =>(x.MaThanhVien==idnd) && (x.CauHoi.id==id))).ToList();
            foreach (var i in lst)
            {
                co =i.DaTl == true ? co + 1 : co;
            }
            KetQua kq = new KetQua();
            kq.MaThanhVien = idnd;
            kq.MaDeThi = id;
            kq.Diem = co.ToString();
            ViewBag.socau = xuly(id);
            ViewBag.Diemthi = co;
            db.KetQuas.Add(kq);
            db.SaveChanges();
            return View();
        }
    }
}