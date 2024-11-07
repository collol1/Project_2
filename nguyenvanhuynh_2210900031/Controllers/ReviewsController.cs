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
    public class ReviewsController : Controller
    {
        private nguyenvanhuynh_k22cntt3_2210900031Entities1 db = new nguyenvanhuynh_k22cntt3_2210900031Entities1();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Member).Include(r => r.Product);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.ReviewID = new SelectList(db.Members, "MemberID", "Username");
            ViewBag.ReviewID = new SelectList(db.Products, "ProductID", "MemberID");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,MemberID,ProductID,Rating,Comment,CreatedAt")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewID = new SelectList(db.Members, "MemberID", "Username", review.ReviewID);
            ViewBag.ReviewID = new SelectList(db.Products, "ProductID", "MemberID", review.ReviewID);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewID = new SelectList(db.Members, "MemberID", "Username", review.ReviewID);
            ViewBag.ReviewID = new SelectList(db.Products, "ProductID", "MemberID", review.ReviewID);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,MemberID,ProductID,Rating,Comment,CreatedAt")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewID = new SelectList(db.Members, "MemberID", "Username", review.ReviewID);
            ViewBag.ReviewID = new SelectList(db.Products, "ProductID", "MemberID", review.ReviewID);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
