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
    public class odalarımızController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/odalarımız
        public ActionResult Index()
        {
            return View(db.odalarımız.ToList());
        }

        // GET: Admin/odalarımız/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            odalarımız odalarımız = db.odalarımız.Find(id);
            if (odalarımız == null)
            {
                return HttpNotFound();
            }
            return View(odalarımız);
        }

        // GET: Admin/odalarımız/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/odalarımız/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "odalarID,odaTürü,odaKat,odaBilgi,kalanOdasayisi,odaÜcreti,genelodadetayi,odaResim,basliklar")] odalarımız odalarımız)
        {
            if (ModelState.IsValid)
            {
                db.odalarımız.Add(odalarımız);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odalarımız);
        }

        // GET: Admin/odalarımız/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            odalarımız odalarımız = db.odalarımız.Find(id);
            if (odalarımız == null)
            {
                return HttpNotFound();
            }
            return View(odalarımız);
        }

        // POST: Admin/odalarımız/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "odalarID,odaTürü,odaKat,odaBilgi,kalanOdasayisi,odaÜcreti,genelodadetayi,odaResim,basliklar")] odalarımız odalarımız)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odalarımız).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odalarımız);
        }

        // GET: Admin/odalarımız/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            odalarımız odalarımız = db.odalarımız.Find(id);
            if (odalarımız == null)
            {
                return HttpNotFound();
            }
            return View(odalarımız);
        }

        // POST: Admin/odalarımız/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            odalarımız odalarımız = db.odalarımız.Find(id);
            db.odalarımız.Remove(odalarımız);
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
