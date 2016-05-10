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
    public class RestuarantsController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/Restuarants
        public ActionResult Index()
        {
            return View(db.Restuarant.ToList());
        }

        // GET: Admin/Restuarants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarant.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // GET: Admin/Restuarants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Restuarants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "restuarantID,restuarantResim,restuarantBilgi,resim2,resim3,resim4,resim5,resim6")] Restuarant restuarant)
        {
            if (ModelState.IsValid)
            {
                db.Restuarant.Add(restuarant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restuarant);
        }

        // GET: Admin/Restuarants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarant.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // POST: Admin/Restuarants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "restuarantID,restuarantResim,restuarantBilgi,resim2,resim3,resim4,resim5,resim6")] Restuarant restuarant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restuarant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restuarant);
        }

        // GET: Admin/Restuarants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarant.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // POST: Admin/Restuarants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restuarant restuarant = db.Restuarant.Find(id);
            db.Restuarant.Remove(restuarant);
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
