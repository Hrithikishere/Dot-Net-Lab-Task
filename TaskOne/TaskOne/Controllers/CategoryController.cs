using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskOne.EF;

namespace TaskOne.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Categories.Find(Id);
            var datas = (
                from d in db.Categories
                where d.Id == Id
                select d).SingleOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Categories.Find(category.Id);
            data.Name = category.Name;
            
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        public ActionResult Delete(int Id)
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Categories.Find(Id);
            db.Categories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        public ActionResult Details()
        {
            TaskOneEntities db = new TaskOneEntities();
            var data = db.Categories.ToList();
            return View(data);
        }
    }
}