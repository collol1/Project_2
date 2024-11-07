using Microsoft.Ajax.Utilities;
using nguyenvanhuynh_2210900031.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenvanhuynh_2210900031.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["Admin"] != null)
            {
                var Member = Session["Admin"] as Admin;
                ViewBag.FullName = Member.Username;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}