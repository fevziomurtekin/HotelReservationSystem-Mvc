using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otelwebsitesi.Models;
namespace Web_proje1.Controllers
{
    public class OtelController : Controller
    {

        // GET: Otel
        otelEntities db = new otelEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hakkımızda()
        {
            ViewBag.hakkimizda = db.hakkimizda.ToList();
            return View();
        }
        public ActionResult Salonlarımız()
        {
            ViewBag.slider = db.sliderbilgi.ToList();
            ViewBag.salonlar = db.Salonlar.ToList();
            return View();
        }
        public ActionResult Odalarımız()
        {
         
            ViewBag.slider = db.sliderbilgi.ToList();
            ViewBag.odalar = db.odalarımız.ToList();
           
            return View();
        }
        public ActionResult kampanya()
        {
            return View();
        }
        public ActionResult İK()
        {
            ViewBag.ik = db.insankaynaklari.ToList();
            return View();
        }
   
        public ActionResult Rezervasyon()
        {
            ViewBag.ikikisilik = db.odalarımız.Where(x => x.odaTürü == "ikikisilik").GroupBy(x => x.odaTürü).Select(x => x.Sum(y => y.kalanOdasayisi));
            ViewBag.aileodasi = db.odalarımız.Where(x => x.odaTürü == "aileodasi").GroupBy(x => x.odaTürü).Select(x => x.Sum(y => y.kalanOdasayisi));
            ViewBag.ückisilik = db.odalarımız.Where(x => x.odaTürü == "ückisilik").GroupBy(x => x.odaTürü).Select(x => x.Sum(y => y.kalanOdasayisi));
            ViewBag.suitodasi = db.odalarımız.Where(x => x.odaTürü == "suitsodasi").GroupBy(x => x.odaTürü).Select(x => x.Sum(y => y.kalanOdasayisi));
            ViewBag.sorgu = db.odalarımız.ToList();
            ViewBag.odalar1 = db.odalarımız.Where(x => x.odalarID == 1);
            ViewBag.odalar2 = db.odalarımız.Where(x => x.odalarID == 5);
            ViewBag.odalar3 = db.odalarımız.Where(x => x.odalarID == 9);
            ViewBag.odalar4 = db.odalarımız.Where(x => x.odalarID == 13);
            odalarımız model = new odalarımız();
            List<odalarımız> oda = db.odalarımız.ToList();  
            ViewBag.oda = oda;
            return View();

        }
        [HttpPost]
        public ActionResult Rezervasyon(rezervasyonumuz rez)
        {
            //rezervasyonumuz rezveri = new rezervasyonumuz();
            //rezveri.cikistarihi = rez.cikistarihi.Date;
            //rezveri.giristarihi = rez.giristarihi.Date;
            //rezveri.yetiskinsayisi = Int32.Parse(rez.kalacakyetiskin.ToString());
            //rezveri.odaKat = rez.odaKat.ToString();
            //rezveri.odaTürü = rez.odaTürü.ToString();
            db.rezervasyonumuz.Add(rez);
            db.SaveChanges();
            return View();
        }
        public ActionResult ResBar()
        {
            ViewBag.Restuarant = db.Restuarant.ToList();
            return View();
        }
        public ActionResult İletisim()
        {
            return View();
        }
            
        public ActionResult rezbilgi()
        {
            ViewBag.sorgu = db.rezervasyonumuz.OrderByDescending(x => x.rezervasyonID).Take(1);
            return View();
        }

    
        public ActionResult Sorgu()
        {
            //ViewBag.iki = db.Odalar.Where(x => x.odaTuru == "ikikisilik");
           
          
            return View();
        }
      
    }
}