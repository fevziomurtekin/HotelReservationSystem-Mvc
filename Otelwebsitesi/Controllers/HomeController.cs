using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otelwebsitesi.Models;
namespace Otelwebsitesi.Controllers
{
    public class HomeController : Controller
    {
        otelEntities db = new otelEntities();
        public ActionResult Index()
        {
            ViewBag.restuarant = db.Restuarant.ToList();
            ViewBag.slider = db.sliderbilgi.ToList();
            ViewBag.odalar = db.odalarımız.ToList();
            ViewBag.salonlar = db.Salonlar.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
 
    }
}