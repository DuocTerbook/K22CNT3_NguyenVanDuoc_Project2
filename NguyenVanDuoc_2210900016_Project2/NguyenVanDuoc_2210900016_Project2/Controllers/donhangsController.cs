using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenVanDuoc_2210900016_Project2.Models;

namespace NguyenVanDuoc_2210900016_Project2.Controllers
{
    public class donhangsController : Controller
    {
        private NguyenVanDuoc_2210900016_Project2Entities db = new NguyenVanDuoc_2210900016_Project2Entities();

        // GET: donhangs
        public ActionResult Index()
        {
            var donhangs = db.donhangs.Include(d => d.khachhang);
            return View(donhangs.ToList());
        }

        // GET: donhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // GET: donhangs/Create
        public ActionResult Create()
        {
            ViewBag.Makhach = new SelectList(db.khachhangs, "MaKhach", "HoTen");
            return View();
        }

        // POST: donhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDon,Makhach,NgayDatHang,TongGiaTri,ThanhToan")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.donhangs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Makhach = new SelectList(db.khachhangs, "MaKhach", "HoTen", donhang.Makhach);
            return View(donhang);
        }

        // GET: donhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Makhach = new SelectList(db.khachhangs, "MaKhach", "HoTen", donhang.Makhach);
            return View(donhang);
        }

        // POST: donhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDon,Makhach,NgayDatHang,TongGiaTri,ThanhToan")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Makhach = new SelectList(db.khachhangs, "MaKhach", "HoTen", donhang.Makhach);
            return View(donhang);
        }

        // GET: donhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: donhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            donhang donhang = db.donhangs.Find(id);
            db.donhangs.Remove(donhang);
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
