using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyCollecter.Models;

namespace MoneyCollecter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reciept reciept)
        {
            if (ModelState.IsValid)
            {
                CollectorDB db = new CollectorDB();
                db.Reciepts.Add(reciept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Index();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
