using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LG_Dashboard.Data;

namespace LG_Dashboard.Controllers
{
    public class HomeController : Controller
    {

        private LGConfigurator2019Entities db = new LGConfigurator2019Entities();
        private LGConfigurator2019Entities dbtracking = new LGConfigurator2019Entities();

        public ActionResult Index()
        {
            ViewBag.Message = "National";
            var products = db.Products.Include(p => p.Area).Include(p => p.Color);
            return View(products.ToList());
        }

        public ActionResult Location()
        {
            ViewBag.Message = "By Location";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            dbtracking.Dispose();

            base.Dispose(disposing);
        }

    }
}