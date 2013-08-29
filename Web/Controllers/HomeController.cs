using AttributeRouting;
using AttributeRouting.Web.Http;
using Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [RoutePrefix("/")]
    public class HomeController : Controller
    {
        [GET("/")]
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult History()
        {
            var reciepts = new RecieptManager();
            var viewModel = new HistoryViewModel();

            viewModel.Reciepts = reciepts.GetAllReciepts();
            return View(viewModel);
        }
    }
}
