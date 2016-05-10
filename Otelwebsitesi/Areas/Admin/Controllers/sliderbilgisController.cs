using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Otelwebsitesi.Models;

namespace Otelwebsitesi.Areas.Admin.Controllers
{
    public class sliderbilgisController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/sliderbilgis
        public ActionResult Index()
        {
            return View(db.sliderbilgi.ToList());
        }

        // GET: Admin/sliderbilgis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sliderbilgi sliderbilgi = db.sliderbilgi.Find(id);
            if (sliderbilgi == null)
            {
                return HttpNotFound();
            }
            return View(sliderbilgi);
        }

        // GET: Admin/sliderbilgis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/sliderbilgis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sliderbilgiID,sliderfoto1,sliderfoto2,sliderfoto3,sliderfoto4,slidertext1,slidertext2,slidertext3,slidertext4,kategori")] sliderbilgi sliderbilgi)
        {
            if (ModelState.IsValid)
            {
                db.sliderbilgi.Add(sliderbilgi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sliderbilgi);
        }

        // GET: Admin/sliderbilgis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sliderbilgi sliderbilgi = db.sliderbilgi.Find(id);
            if (sliderbilgi == null)
            {
                return HttpNotFound();
            }
            return View(sliderbilgi);
        }

        // POST: Admin/sliderbilgis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sliderbilgiID,sliderfoto1,sliderfoto2,sliderfoto3,sliderfoto4,slidertext1,slidertext2,slidertext3,slidertext4,kategori")] sliderbilgi sliderbilgi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sliderbilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sliderbilgi);
        }

        // GET: Admin/sliderbilgis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sliderbilgi sliderbilgi = db.sliderbilgi.Find(id);
            if (sliderbilgi == null)
            {
                return HttpNotFound();
            }
            return View(sliderbilgi);
        }

        // POST: Admin/sliderbilgis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sliderbilgi sliderbilgi = db.sliderbilgi.Find(id);
            db.sliderbilgi.Remove(sliderbilgi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
