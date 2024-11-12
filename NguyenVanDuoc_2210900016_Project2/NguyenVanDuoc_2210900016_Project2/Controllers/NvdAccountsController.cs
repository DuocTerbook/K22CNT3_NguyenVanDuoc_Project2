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
    public class NvdAccountsController : Controller
    {
        private AccountEntities db = new AccountEntities();

        // GET: NvdAccounts
        public ActionResult Index()
        {
            return View(db.NvdAccounts.ToList());
        }

        // GET: NvdAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdAccount nvdAccount = db.NvdAccounts.Find(id);
            if (nvdAccount == null)
            {
                return HttpNotFound();
            }
            return View(nvdAccount);
        }

        // GET: NvdAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NvdAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NvdID,NvdUserName,NvdPassWord,NvdFullName,NvdEmail,NvdPhone,NvdActive")] NvdAccount nvdAccount)
        {
            if (ModelState.IsValid)
            {
                db.NvdAccounts.Add(nvdAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nvdAccount);
        }

        // GET: NvdAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdAccount nvdAccount = db.NvdAccounts.Find(id);
            if (nvdAccount == null)
            {
                return HttpNotFound();
            }
            return View(nvdAccount);
        }

        // POST: NvdAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NvdID,NvdUserName,NvdPassWord,NvdFullName,NvdEmail,NvdPhone,NvdActive")] NvdAccount nvdAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvdAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nvdAccount);
        }

        // GET: NvdAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdAccount nvdAccount = db.NvdAccounts.Find(id);
            if (nvdAccount == null)
            {
                return HttpNotFound();
            }
            return View(nvdAccount);
        }

        // POST: NvdAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NvdAccount nvdAccount = db.NvdAccounts.Find(id);
            db.NvdAccounts.Remove(nvdAccount);
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
        // login
        public ActionResult Login()
        {
            var nvdModel = new NvdAccount();
            return View(nvdModel);
        }
        [HttpPost]
        public ActionResult Login(NvdAccount nvdAccount)
        {
            var nvdCheck = db.NvdAccounts.Where(x => x.NvdUserName.Equals(nvdAccount.NvdUserName) && x.NvdPassWord.Equals(nvdAccount.NvdPassWord)).FirstOrDefault();
            if (nvdCheck != null)
            {
                // Lưu session
                Session["NvdAccount"] = nvdCheck;
                return Redirect("/");
            }
            return View(nvdAccount);
        }
        // GET: NvdAccounts/Register
        public ActionResult Register()
        {
            var nvdModel = new NvdAccount();
            return View(nvdModel);
        }

        // POST: NvdAccounts/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "NvdUserName,NvdPassWord,NvdFullName,NvdEmail,NvdPhone,NvdActive")] NvdAccount nvdAccount)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên người dùng đã tồn tại chưa
                var nvdExist = db.NvdAccounts.Any(x => x.NvdUserName == nvdAccount.NvdUserName);
                if (nvdExist)
                {
                    ModelState.AddModelError("NvdUserName", "Tên người dùng đã tồn tại.");
                    return View(nvdAccount);
                }

                // Thêm tài khoản mới
                db.NvdAccounts.Add(nvdAccount);
                db.SaveChanges();

                // Sau khi đăng ký thành công, chuyển hướng đến trang Login
                return RedirectToAction("Login");
            }
            return View(nvdAccount);
        }
    }
}
