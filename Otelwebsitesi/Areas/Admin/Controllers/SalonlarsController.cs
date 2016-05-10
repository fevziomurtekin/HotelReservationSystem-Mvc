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
    public class SalonlarsController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/Salonlars
        public ActionResult Index()
        {
            return View(db.Salonlar.ToList());
        }

        // GET: Admin/Salonlars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salonlar salonlar = db.Salonlar.Find(id);
            if (salonlar == null)
            {
                return HttpNotFound();
            }
            return View(salonlar);
        }

        // GET: Admin/Salonlars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Salonlars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "salonlarID,salonResmi,salonBilgi,salonBaslik,salonbilgisatiri1,salonbilgisatiri2,salonbilgisatiri3,salonbilgisatiri4")] Salonlar salonlar)
        {
            if (ModelState.IsValid)
            {
                db.Salonlar.Add(salonlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salonlar);
        }

        // GET: Admin/Salonlars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salonlar salonlar = db.Salonlar.Find(id);
            if (salonlar == null)
            {
                return HttpNotFound();
            }
            return View(salonlar);
        }

        // POST: Admin/Salonlars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "salonlarID,salonResmi,salonBilgi,salonBaslik,salonbilgisatiri1,salonbilgisatiri2,salonbilgisatiri3,salonbilgisatiri4")] Salonlar salonlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salonlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salonlar);
        }

        // GET: Admin/Salonlars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salonlar salonlar = db.Salonlar.Find(id);
            if (salonlar == null)
            {
                return HttpNotFound();
            }
            return View(salonlar);
        }

        // POST: Admin/Salonlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salonlar salonlar = db.Salonlar.Find(id);
            db.Salonlar.Remove(salonlar);
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
