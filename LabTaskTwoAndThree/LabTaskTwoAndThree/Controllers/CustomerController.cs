using LabTaskTwoAndThree.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTaskTwoAndThree.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
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

        //need session while login to store id
        public ActionResult Profile()
        {
            var db = new MidTaskEntities();
            var customerData = db.Users.Find();
            return View(customerData);
        }

        //need session while login to store id
        public ActionResult Order()
        {
            var db = new MidTaskEntities();
            var customerData = db.Users.Find();
            return View(customerData);
        }

        //find something like TempData or Session to store data in the cart

    }
}