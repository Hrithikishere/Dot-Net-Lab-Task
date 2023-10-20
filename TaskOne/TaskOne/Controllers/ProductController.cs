using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskOne.EF;

namespace TaskOne.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Products.Find(Id);
            var datas = (
                from d in db.Products
                where d.Id == Id
                select d).SingleOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Products.Find(product.Id);
            data.Name = product.Name;
            data.Price = product.Price;
            data.CategoryId = product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        public ActionResult Delete(int Id)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Products.Find(Id);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        public ActionResult Details()
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Products.ToList();
            return View(data);
        }
    }
}