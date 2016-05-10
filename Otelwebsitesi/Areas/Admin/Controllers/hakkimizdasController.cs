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
    public class hakkimizdasController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/hakkimizdas
        public ActionResult Index()
        {
            return View(db.hakkimizda.ToList());
        }

        // GET: Admin/hakkimizdas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hakkimizda hakkimizda = db.hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // GET: Admin/hakkimizdas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/hakkimizdas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hakkimizdaID,hakkimizdaBilgi,hakkimizdaResim,hakkimizdaBaslik,hakkimizdasatir1,hakkimizdasatir2,hakkimizdasatir3,hakkimizdasatir4,hakkimizdasatir5,hakkimizdasatir6,hakkimizdasatir7,hakkimizdasatir8,hakkimizdasatir9,hakkimizdaBaslik1,hakkimizdaBilgi1,hakkimizdaBilgi2,hakkimizdaBaslik2,hakkimizdaBaslik3,hakkimizdaBilgi3,hakkimizdaBaslik4,hakkimizdaBilgi4,hakkimizdaBaslik5,hakkimizdaBilgi5")] hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.hakkimizda.Add(hakkimizda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hakkimizda);
        }

        // GET: Admin/hakkimizdas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hakkimizda hakkimizda = db.hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Admin/hakkimizdas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hakkimizdaID,hakkimizdaBilgi,hakkimizdaResim,hakkimizdaBaslik,hakkimizdasatir1,hakkimizdasatir2,hakkimizdasatir3,hakkimizdasatir4,hakkimizdasatir5,hakkimizdasatir6,hakkimizdasatir7,hakkimizdasatir8,hakkimizdasatir9,hakkimizdaBaslik1,hakkimizdaBilgi1,hakkimizdaBilgi2,hakkimizdaBaslik2,hakkimizdaBaslik3,hakkimizdaBilgi3,hakkimizdaBaslik4,hakkimizdaBilgi4,hakkimizdaBaslik5,hakkimizdaBilgi5")] hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hakkimizda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hakkimizda);
        }

        // GET: Admin/hakkimizdas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hakkimizda hakkimizda = db.hakkimizda.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Admin/hakkimizdas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hakkimizda hakkimizda = db.hakkimizda.Find(id);
            db.hakkimizda.Remove(hakkimizda);
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
