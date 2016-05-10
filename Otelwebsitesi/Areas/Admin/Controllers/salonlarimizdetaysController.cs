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
    public class salonlarimizdetaysController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/salonlarimizdetays
        public ActionResult Index()
        {
            var salonlarimizdetay = db.salonlarimizdetay.Include(s => s.Salonlar);
            return View(salonlarimizdetay.ToList());
        }

        // GET: Admin/salonlarimizdetays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salonlarimizdetay salonlarimizdetay = db.salonlarimizdetay.Find(id);
            if (salonlarimizdetay == null)
            {
                return HttpNotFound();
            }
            return View(salonlarimizdetay);
        }

        // GET: Admin/salonlarimizdetays/Create
        public ActionResult Create()
        {
            ViewBag.salonlarID = new SelectList(db.Salonlar, "salonlarID", "salonResmi");
            return View();
        }

        // POST: Admin/salonlarimizdetays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "salondetayID,salondetayBilgi,dil,salonlarID")] salonlarimizdetay salonlarimizdetay)
        {
            if (ModelState.IsValid)
            {
                db.salonlarimizdetay.Add(salonlarimizdetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.salonlarID = new SelectList(db.Salonlar, "salonlarID", "salonResmi", salonlarimizdetay.salonlarID);
            return View(salonlarimizdetay);
        }

        // GET: Admin/salonlarimizdetays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salonlarimizdetay salonlarimizdetay = db.salonlarimizdetay.Find(id);
            if (salonlarimizdetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.salonlarID = new SelectList(db.Salonlar, "salonlarID", "salonResmi", salonlarimizdetay.salonlarID);
            return View(salonlarimizdetay);
        }

        // POST: Admin/salonlarimizdetays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "salondetayID,salondetayBilgi,dil,salonlarID")] salonlarimizdetay salonlarimizdetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salonlarimizdetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.salonlarID = new SelectList(db.Salonlar, "salonlarID", "salonResmi", salonlarimizdetay.salonlarID);
            return View(salonlarimizdetay);
        }

        // GET: Admin/salonlarimizdetays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salonlarimizdetay salonlarimizdetay = db.salonlarimizdetay.Find(id);
            if (salonlarimizdetay == null)
            {
                return HttpNotFound();
            }
            return View(salonlarimizdetay);
        }

        // POST: Admin/salonlarimizdetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salonlarimizdetay salonlarimizdetay = db.salonlarimizdetay.Find(id);
            db.salonlarimizdetay.Remove(salonlarimizdetay);
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
