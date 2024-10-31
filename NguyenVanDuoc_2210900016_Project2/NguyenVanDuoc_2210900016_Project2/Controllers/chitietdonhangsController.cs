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
    public class chitietdonhangsController : Controller
    {
        private NguyenVanDuoc_2210900016_Project2Entities db = new NguyenVanDuoc_2210900016_Project2Entities();

        // GET: chitietdonhangs
        public ActionResult Index()
        {
            var chitietdonhangs = db.chitietdonhangs.Include(c => c.donhang).Include(c => c.sanpham);
            return View(chitietdonhangs.ToList());
        }

        // GET: chitietdonhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdonhang chitietdonhang = db.chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // GET: chitietdonhangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDon = new SelectList(db.donhangs, "MaDon", "MaDon");
            ViewBag.MaSP = new SelectList(db.sanphams, "MaSP", "TenSP");
            return View();
        }

        // POST: chitietdonhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTDH,MaDon,MaSP,SoLuong")] chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.chitietdonhangs.Add(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDon = new SelectList(db.donhangs, "MaDon", "MaDon", chitietdonhang.MaDon);
            ViewBag.MaSP = new SelectList(db.sanphams, "MaSP", "TenSP", chitietdonhang.MaSP);
            return View(chitietdonhang);
        }

        // GET: chitietdonhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdonhang chitietdonhang = db.chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDon = new SelectList(db.donhangs, "MaDon", "MaDon", chitietdonhang.MaDon);
            ViewBag.MaSP = new SelectList(db.sanphams, "MaSP", "TenSP", chitietdonhang.MaSP);
            return View(chitietdonhang);
        }

        // POST: chitietdonhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTDH,MaDon,MaSP,SoLuong")] chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDon = new SelectList(db.donhangs, "MaDon", "MaDon", chitietdonhang.MaDon);
            ViewBag.MaSP = new SelectList(db.sanphams, "MaSP", "TenSP", chitietdonhang.MaSP);
            return View(chitietdonhang);
        }

        // GET: chitietdonhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdonhang chitietdonhang = db.chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // POST: chitietdonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chitietdonhang chitietdonhang = db.chitietdonhangs.Find(id);
            db.chitietdonhangs.Remove(chitietdonhang);
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
