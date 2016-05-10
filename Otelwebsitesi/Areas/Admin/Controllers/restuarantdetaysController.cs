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
    public class restuarantdetaysController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/restuarantdetays
        public ActionResult Index()
        {
            var restuarantdetay = db.restuarantdetay.Include(r => r.Restuarant);
            return View(restuarantdetay.ToList());
        }

        // GET: Admin/restuarantdetays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restuarantdetay restuarantdetay = db.restuarantdetay.Find(id);
            if (restuarantdetay == null)
            {
                return HttpNotFound();
            }
            return View(restuarantdetay);
        }

        // GET: Admin/restuarantdetays/Create
        public ActionResult Create()
        {
            ViewBag.restuarantID = new SelectList(db.Restuarant, "restuarantID", "restuarantResim");
            return View();
        }

        // POST: Admin/restuarantdetays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "restuarantdetayID,restuaranddetayBilgi,dil,restuarantID")] restuarantdetay restuarantdetay)
        {
            if (ModelState.IsValid)
            {
                db.restuarantdetay.Add(restuarantdetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.restuarantID = new SelectList(db.Restuarant, "restuarantID", "restuarantResim", restuarantdetay.restuarantID);
            return View(restuarantdetay);
        }

        // GET: Admin/restuarantdetays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restuarantdetay restuarantdetay = db.restuarantdetay.Find(id);
            if (restuarantdetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.restuarantID = new SelectList(db.Restuarant, "restuarantID", "restuarantResim", restuarantdetay.restuarantID);
            return View(restuarantdetay);
        }

        // POST: Admin/restuarantdetays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "restuarantdetayID,restuaranddetayBilgi,dil,restuarantID")] restuarantdetay restuarantdetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restuarantdetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.restuarantID = new SelectList(db.Restuarant, "restuarantID", "restuarantResim", restuarantdetay.restuarantID);
            return View(restuarantdetay);
        }

        // GET: Admin/restuarantdetays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restuarantdetay restuarantdetay = db.restuarantdetay.Find(id);
            if (restuarantdetay == null)
            {
                return HttpNotFound();
            }
            return View(restuarantdetay);
        }

        // POST: Admin/restuarantdetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            restuarantdetay restuarantdetay = db.restuarantdetay.Find(id);
            db.restuarantdetay.Remove(restuarantdetay);
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
