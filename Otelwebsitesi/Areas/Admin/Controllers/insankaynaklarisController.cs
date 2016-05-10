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
    public class insankaynaklarisController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/insankaynaklaris
        public ActionResult Index()
        {
            var insankaynaklari = db.insankaynaklari.Include(i => i.insankaynaklaridetay);
            return View(insankaynaklari.ToList());
        }

        // GET: Admin/insankaynaklaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insankaynaklari insankaynaklari = db.insankaynaklari.Find(id);
            if (insankaynaklari == null)
            {
                return HttpNotFound();
            }
            return View(insankaynaklari);
        }

        // GET: Admin/insankaynaklaris/Create
        public ActionResult Create()
        {
            ViewBag.ikID = new SelectList(db.insankaynaklaridetay, "ikdetayID", "ikdetayBilgi");
            return View();
        }

        // POST: Admin/insankaynaklaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ikID,ikResim,ikBaslik,ikBaslik1,ikBaslik3,ikBaslik4,ikBilgi,ikBilgi1,ikBilgi2,ikBilgi3,ikBilgi4,ikBilgi5,ikBilgi6,ikBilgi7,ikBilgi8,ikBilgi9")] insankaynaklari insankaynaklari)
        {
            if (ModelState.IsValid)
            {
                db.insankaynaklari.Add(insankaynaklari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ikID = new SelectList(db.insankaynaklaridetay, "ikdetayID", "ikdetayBilgi", insankaynaklari.ikID);
            return View(insankaynaklari);
        }

        // GET: Admin/insankaynaklaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insankaynaklari insankaynaklari = db.insankaynaklari.Find(id);
            if (insankaynaklari == null)
            {
                return HttpNotFound();
            }
            ViewBag.ikID = new SelectList(db.insankaynaklaridetay, "ikdetayID", "ikdetayBilgi", insankaynaklari.ikID);
            return View(insankaynaklari);
        }

        // POST: Admin/insankaynaklaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ikID,ikResim,ikBaslik,ikBaslik1,ikBaslik3,ikBaslik4,ikBilgi,ikBilgi1,ikBilgi2,ikBilgi3,ikBilgi4,ikBilgi5,ikBilgi6,ikBilgi7,ikBilgi8,ikBilgi9")] insankaynaklari insankaynaklari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insankaynaklari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ikID = new SelectList(db.insankaynaklaridetay, "ikdetayID", "ikdetayBilgi", insankaynaklari.ikID);
            return View(insankaynaklari);
        }

        // GET: Admin/insankaynaklaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insankaynaklari insankaynaklari = db.insankaynaklari.Find(id);
            if (insankaynaklari == null)
            {
                return HttpNotFound();
            }
            return View(insankaynaklari);
        }

        // POST: Admin/insankaynaklaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            insankaynaklari insankaynaklari = db.insankaynaklari.Find(id);
            db.insankaynaklari.Remove(insankaynaklari);
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
