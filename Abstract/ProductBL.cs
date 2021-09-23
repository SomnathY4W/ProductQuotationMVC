using ProductQuotationMVC.EFDB;
using ProductQuotationMVC.Interfaces;
using ProductQuotationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductQuotationMVC.Abstract
{
    public class ProductBL : IProductBL
    {
        private ProductQuotationDBEntities db = new ProductQuotationDBEntities();


        public int CreateProduct(ProductModel model)
        {
            Product product = new Product();
            product.ProductID = model.ProductID;
            product.ProductName = model.ProductName;
            product.ProductDescription = model.ProductDescription;
            product.ProductDuration = model.ProductDuration;
            product.ProductQuantity = Convert.ToInt32(model.ProductQuantity);
            product.ActiveProduct = Convert.ToBoolean(model.ActiveProduct);
            product.CreatedBy = model.CreatedBy;
            product.CreatedDate = model.CreatedDate;
            product.ModifyBy = model.ModifyBy;
            product.ModifyDate = model.ModifyDate;

            db.Products.Add(product);
            return db.SaveChanges();

        }

        public int EditProduct(Product product)
        {

            product.ModifyDate = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return db.SaveChanges();
        }

        public bool FindProduct(string productName)
        {
            bool productFound = false;
            if (db.Products.Count() > 0)
            {
                productFound = db.Products.Where(p => p.ProductName == productName).Count() > 0;
            }

            return productFound;
        }
    }
}