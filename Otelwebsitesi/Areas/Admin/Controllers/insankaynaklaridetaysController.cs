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
    public class insankaynaklaridetaysController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/insankaynaklaridetays
        public ActionResult Index()
        {
            var insankaynaklaridetay = db.insankaynaklaridetay.Include(i => i.insankaynaklari);
            return View(insankaynaklaridetay.ToList());
        }

        // GET: Admin/insankaynaklaridetays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insankaynaklaridetay insankaynaklaridetay = db.insankaynaklaridetay.Find(id);
            if (insankaynaklaridetay == null)
            {
                return HttpNotFound();
            }
            return View(insankaynaklaridetay);
        }

        // GET: Admin/insankaynaklaridetays/Create
        public ActionResult Create()
        {
            ViewBag.ikdetayID = new SelectList(db.insankaynaklari, "ikID", "ikResim");
            return View();
        }

        // POST: Admin/insankaynaklaridetays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ikdetayID,ikdetayBilgi,dil,ikID")] insankaynaklaridetay insankaynaklaridetay)
        {
            if (ModelState.IsValid)
            {
                db.insankaynaklaridetay.Add(insankaynaklaridetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ikdetayID = new SelectList(db.insankaynaklari, "ikID", "ikResim", insankaynaklaridetay.ikdetayID);
            return View(insankaynaklaridetay);
        }

        // GET: Admin/insankaynaklaridetays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insankaynaklaridetay insankaynaklaridetay = db.insankaynaklaridetay.Find(id);
            if (insankaynaklaridetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.ikdetayID = new SelectList(db.insankaynaklari, "ikID", "ikResim", insankaynaklaridetay.ikdetayID);
            return View(insankaynaklaridetay);
        }

        // POST: Admin/insankaynaklaridetays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ikdetayID,ikdetayBilgi,dil,ikID")] insankaynaklaridetay insankaynaklaridetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insankaynaklaridetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ikdetayID = new SelectList(db.insankaynaklari, "ikID", "ikResim", insankaynaklaridetay.ikdetayID);
            return View(insankaynaklaridetay);
        }

        // GET: Admin/insankaynaklaridetays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insankaynaklaridetay insankaynaklaridetay = db.insankaynaklaridetay.Find(id);
            if (insankaynaklaridetay == null)
            {
                return HttpNotFound();
            }
            return View(insankaynaklaridetay);
        }

        // POST: Admin/insankaynaklaridetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            insankaynaklaridetay insankaynaklaridetay = db.insankaynaklaridetay.Find(id);
            db.insankaynaklaridetay.Remove(insankaynaklaridetay);
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
