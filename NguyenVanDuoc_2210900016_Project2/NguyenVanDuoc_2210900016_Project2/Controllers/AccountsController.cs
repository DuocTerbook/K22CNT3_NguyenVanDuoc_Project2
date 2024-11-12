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
    public class AccountsController : Controller
    {
        private Account_NguyenVanDuoc_Project2Entities db = new Account_NguyenVanDuoc_Project2Entities();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,PassWord,FullName,Email,Phone,Active")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,PassWord,FullName,Email,Phone,Active")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
            var Model = new Account();
            return View(Model);
        }
        [HttpPost]
        public ActionResult Login(Account Account)
        {
            var Check = db.Accounts.Where(x => x.UserName.Equals(Account.UserName) && x.PassWord.Equals(Account.PassWord)).FirstOrDefault();
            if (Check != null)
            {
                // Lưu session
                Session["NvdAccount"] = Check;
                return Redirect("/");
            }
            return View(Account);
        }
        // GET: NvdAccounts/Register
        public ActionResult Register()
        {
            var Model = new Account();
            return View(Model);
        }

        // POST: NvdAccounts/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName,PassWord,FullName,Email,Phone,Active")] Account Account)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên người dùng đã tồn tại chưa
                var nvdExist = db.Accounts.Any(x => x.UserName == Account.UserName);
                if (nvdExist)
                {
                    ModelState.AddModelError("NvdUserName", "Tên người dùng đã tồn tại.");
                    return View(Account);
                }

                // Thêm tài khoản mới
                db.Accounts.Add(Account);
                db.SaveChanges();

                // Sau khi đăng ký thành công, chuyển hướng đến trang Login
                return RedirectToAction("Login");
            }
            return View(Account);
        }
    }
}
