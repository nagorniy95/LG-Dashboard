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
    public class ProductsController : Controller
    {
        private LGConfigurator2019Entities db = new LGConfigurator2019Entities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Area).Include(p => p.Color);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaName");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Name_EN");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,AreaId,ColorId,Name_EN,Name_FR,Description_EN,Description_FR,MSRP,SalePrice,ModelNumber,BestBuyWebCode,Disclaimer_EN,Disclaimer_FR,ThumbnailUrl,DateCreated,DateLastEdited,IsAutoArchive,IsManualArchive,IsCatalogOnly")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaName", product.AreaId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Name_EN", product.ColorId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaName", product.AreaId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Name_EN", product.ColorId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,AreaId,ColorId,Name_EN,Name_FR,Description_EN,Description_FR,MSRP,SalePrice,ModelNumber,BestBuyWebCode,Disclaimer_EN,Disclaimer_FR,ThumbnailUrl,DateCreated,DateLastEdited,IsAutoArchive,IsManualArchive,IsCatalogOnly")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaName", product.AreaId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Name_EN", product.ColorId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
