using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductQuotationMVC.EFDB;
using Microsoft.AspNet.Identity;
using ProductQuotationMVC.Models;
using ProductQuotationMVC.Interfaces;

namespace ProductQuotationMVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ProductQuotationDBEntities db = new ProductQuotationDBEntities();

        public readonly IProductBL _productBL;

        public ProductsController(IProductBL productBL)
        {
            this._productBL = productBL;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
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
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductDescription,ProductQuantity,ProductDuration,ActiveProduct")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedBy = Abstract.AbstructUserClass.GetUserID(User.Identity.GetUserId());
                product.CreatedDate = DateTime.Now;
                this._productBL.CreateProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //#1: this code we write here so each time we will add we don't need to get the userid for createdby once the page will load it will hold the value and with each request it will send that value
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

            product.ModifyBy = Abstract.AbstructUserClass.GetUserID(User.Identity.GetUserId());    //refer to #1
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductDescription,ProductQuantity,ProductDuration,ActiveProduct")] Product product)
        {
            if (ModelState.IsValid)
            {
                this._productBL.EditProduct(product);
                return RedirectToAction("Index");
            }
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
