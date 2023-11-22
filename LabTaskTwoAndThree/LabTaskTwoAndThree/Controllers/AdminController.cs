using LabTaskTwoAndThree.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTaskTwoAndThree.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            var db = new MidTaskEntities();
            var data = db.Products.ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var db = new MidTaskEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            var db = new MidTaskEntities();
            var productData = db.Products.Find(Id);
            return View(productData);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            var db = new MidTaskEntities();
            var productData = db.Products.Find(product.Id);
            productData.Name = product.Name;
            productData.Price = product.Price;
            productData.Quantity = product.Quantity;
            productData.CategoryId = product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        public ActionResult Customer()
        {
            var db = new MidTaskEntities();
            var data = db.Users.Where(c=>c.UserType == "Customer").ToList();
            return View(data);
        }

        public ActionResult CustomerProfile(int Id)
        {
            var db = new MidTaskEntities();
            var customerData = db.Users.Find(Id);
            return View(customerData);
        }

        public ActionResult Order()
        {
            var db = new MidTaskEntities();
            var data = db.Orders.ToList();

            return View(data);
        }

        public ActionResult OrderDetails(int Id)
        {
            var db = new MidTaskEntities();
            var orderData = db.ProductOrders.Find(Id);
            return View(orderData);
        }
    }
}