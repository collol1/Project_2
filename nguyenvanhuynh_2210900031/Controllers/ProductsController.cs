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
    public class ProductsController : Controller
    {
        private nguyenvanhuynh_k22cntt3_2210900031Entities1 db = new nguyenvanhuynh_k22cntt3_2210900031Entities1();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Member).Include(p => p.Order).Include(p => p.Review);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.ProductID = new SelectList(db.Members, "MemberID", "Username");
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "MemberID");
            ViewBag.ProductID = new SelectList(db.Reviews, "ReviewID", "MemberID");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,MemberID,CategoryID,ProductName,Description,Price,Condition,ImageURl,CreatedAt,UpdateAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Members, "MemberID", "Username", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "MemberID", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Reviews, "ReviewID", "MemberID", product.ProductID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Members, "MemberID", "Username", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "MemberID", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Reviews, "ReviewID", "MemberID", product.ProductID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,MemberID,CategoryID,ProductName,Description,Price,Condition,ImageURl,CreatedAt,UpdateAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Members, "MemberID", "Username", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "MemberID", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Reviews, "ReviewID", "MemberID", product.ProductID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
