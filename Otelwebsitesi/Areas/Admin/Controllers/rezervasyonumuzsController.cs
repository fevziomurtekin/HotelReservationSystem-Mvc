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
    public class rezervasyonumuzsController : Controller
    {
        private otelEntities db = new otelEntities();

        // GET: Admin/rezervasyonumuzs
        public ActionResult Index()
        {
            var rezervasyonumuz = db.rezervasyonumuz.Include(r => r.odalarımız).Include(r => r.Uye);
            return View(rezervasyonumuz.ToList());
        }

        // GET: Admin/rezervasyonumuzs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezervasyonumuz rezervasyonumuz = db.rezervasyonumuz.Find(id);
            if (rezervasyonumuz == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyonumuz);
        }

        // GET: Admin/rezervasyonumuzs/Create
        public ActionResult Create()
        {
            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü");
            ViewBag.uyeID = new SelectList(db.Uye, "uyeID", "ad");
            return View();
        }

        // POST: Admin/rezervasyonumuzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rezervasyonID,giristarihi,cikistarihi,yetiskinsayisi,Ad,Soyadı,TelefonNumarasi,Eposta,Adresiniz,odalarID,uyeID,odaTürü,odaKat")] rezervasyonumuz rezervasyonumuz)
        {
            if (ModelState.IsValid)
            {
                db.rezervasyonumuz.Add(rezervasyonumuz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü", rezervasyonumuz.odalarID);
            ViewBag.uyeID = new SelectList(db.Uye, "uyeID", "ad", rezervasyonumuz.uyeID);
            return View(rezervasyonumuz);
        }

        // GET: Admin/rezervasyonumuzs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezervasyonumuz rezervasyonumuz = db.rezervasyonumuz.Find(id);
            if (rezervasyonumuz == null)
            {
                return HttpNotFound();
            }
            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü", rezervasyonumuz.odalarID);
            ViewBag.uyeID = new SelectList(db.Uye, "uyeID", "ad", rezervasyonumuz.uyeID);
            return View(rezervasyonumuz);
        }

        // POST: Admin/rezervasyonumuzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rezervasyonID,giristarihi,cikistarihi,yetiskinsayisi,Ad,Soyadı,TelefonNumarasi,Eposta,Adresiniz,odalarID,uyeID,odaTürü,odaKat")] rezervasyonumuz rezervasyonumuz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervasyonumuz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.odalarID = new SelectList(db.odalarımız, "odalarID", "odaTürü", rezervasyonumuz.odalarID);
            ViewBag.uyeID = new SelectList(db.Uye, "uyeID", "ad", rezervasyonumuz.uyeID);
            return View(rezervasyonumuz);
        }

        // GET: Admin/rezervasyonumuzs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezervasyonumuz rezervasyonumuz = db.rezervasyonumuz.Find(id);
            if (rezervasyonumuz == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyonumuz);
        }

        // POST: Admin/rezervasyonumuzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rezervasyonumuz rezervasyonumuz = db.rezervasyonumuz.Find(id);
            db.rezervasyonumuz.Remove(rezervasyonumuz);
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
