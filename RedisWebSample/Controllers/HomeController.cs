using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisWebSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["time"] = DateTime.Now;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.IndexTime = Session["time"];
            ViewBag.Time = DateTime.Now;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}