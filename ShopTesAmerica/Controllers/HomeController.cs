using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTesAmerica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AppBar()
        {
            return PartialView();
        }
        public ActionResult Toast()
        {
            return PartialView();
        }
    }
}