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
    public class odalardetaysController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/odalardetays
        public ActionResult Index()
        {
            var odalardetay = db.odalardetay.Include(o => o.odalarımız);
            return View(odalardetay.ToList());
        }

        // GET: Admin/odalardetays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            odalardetay odalardetay = db.odalardetay.Find(id);
            if (odalardetay == null)
            {
                return HttpNotFound();
            }
            return View(odalardetay);
        }

        // GET: Admin/odalardetays/Create
        public ActionResult Create()
        {
            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü");
            return View();
        }

        // POST: Admin/odalardetays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "odalardetayID,odalardetayBilgi,dil,odalarID")] odalardetay odalardetay)
        {
            if (ModelState.IsValid)
            {
                db.odalardetay.Add(odalardetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü", odalardetay.odalarID);
            return View(odalardetay);
        }

        // GET: Admin/odalardetays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            odalardetay odalardetay = db.odalardetay.Find(id);
            if (odalardetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü", odalardetay.odalarID);
            return View(odalardetay);
        }

        // POST: Admin/odalardetays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "odalardetayID,odalardetayBilgi,dil,odalarID")] odalardetay odalardetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odalardetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü", odalardetay.odalarID);
            return View(odalardetay);
        }

        // GET: Admin/odalardetays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            odalardetay odalardetay = db.odalardetay.Find(id);
            if (odalardetay == null)
            {
                return HttpNotFound();
            }
            return View(odalardetay);
        }

        // POST: Admin/odalardetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            odalardetay odalardetay = db.odalardetay.Find(id);
            db.odalardetay.Remove(odalardetay);
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
