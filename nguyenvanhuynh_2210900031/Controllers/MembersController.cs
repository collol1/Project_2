using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nguyenvanhuynh_2210900031.Models;

namespace nguyenvanhuynh_2210900031.Controllers
{
    public class MembersController : Controller
    {
        private nguyenvanhuynh_k22cntt3_2210900031Entities1 db = new nguyenvanhuynh_k22cntt3_2210900031Entities1();

        // GET: Members
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.Order).Include(m => m.Product).Include(m => m.Review);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Orders, "OrderID", "MemberID");
            ViewBag.MemberID = new SelectList(db.Products, "ProductID", "MemberID");
            ViewBag.MemberID = new SelectList(db.Reviews, "ReviewID", "MemberID");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,Username,Password,Email,PhoneNumber,Adderss,CreatedAt,UpdateAt,Role")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.Orders, "OrderID", "MemberID", member.MemberID);
            ViewBag.MemberID = new SelectList(db.Products, "ProductID", "MemberID", member.MemberID);
            ViewBag.MemberID = new SelectList(db.Reviews, "ReviewID", "MemberID", member.MemberID);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Orders, "OrderID", "MemberID", member.MemberID);
            ViewBag.MemberID = new SelectList(db.Products, "ProductID", "MemberID", member.MemberID);
            ViewBag.MemberID = new SelectList(db.Reviews, "ReviewID", "MemberID", member.MemberID);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,Username,Password,Email,PhoneNumber,Adderss,CreatedAt,UpdateAt,Role")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Orders, "OrderID", "MemberID", member.MemberID);
            ViewBag.MemberID = new SelectList(db.Products, "ProductID", "MemberID", member.MemberID);
            ViewBag.MemberID = new SelectList(db.Reviews, "ReviewID", "MemberID", member.MemberID);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
