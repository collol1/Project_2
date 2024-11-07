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
    public class OrdersController : Controller
    {
        private nguyenvanhuynh_k22cntt3_2210900031Entities1 db = new nguyenvanhuynh_k22cntt3_2210900031Entities1();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Member).Include(o => o.Product);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Members, "MemberID", "Username");
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "MemberID");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,MemberID,ProductID,Quantity,TotalPrice,OrderDate,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Members, "MemberID", "Username", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "MemberID", order.OrderID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Members, "MemberID", "Username", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "MemberID", order.OrderID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,MemberID,ProductID,Quantity,TotalPrice,OrderDate,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Members, "MemberID", "Username", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "MemberID", order.OrderID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
