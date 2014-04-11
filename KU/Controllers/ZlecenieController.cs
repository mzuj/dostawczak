using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KU.Models;

namespace KU.Controllers
{
    public class ZlecenieController : Controller
    {
        private ZlecenieEntities db = new ZlecenieEntities();

        // GET: /Zlecenie/
        public ActionResult Index()
        {
            var zlecenie = from s in db.Zlecenie
                           select s;
            zlecenie = zlecenie.Where(s => s.AspNetUsers.UserName.Contains(User.Identity.Name));
            return View(zlecenie.ToList());
        }

        // GET: /Zlecenie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            return View(zlecenie);
        }

        // GET: /Zlecenie/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: /Zlecenie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ZlecenieID,Miejsce_nadania,Miejsce_dostawy,Odbiorca,Zleceniodawca,Zawartosc,Ilosc_opakowan,Rodzaj_opakowan,Materialy_niebezpieczne,Pobranie_za_przesylke,Priorytet,Kategoria_zlecenia,ID")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Zlecenie.Add(zlecenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.ID);
            return View(zlecenie);
        }

        // GET: /Zlecenie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.ID);
            return View(zlecenie);
        }

        // POST: /Zlecenie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ZlecenieID,Miejsce_nadania,Miejsce_dostawy,Odbiorca,Zleceniodawca,Zawartosc,Ilosc_opakowan,Rodzaj_opakowan,Materialy_niebezpieczne,Pobranie_za_przesylke,Priorytet,Kategoria_zlecenia,ID")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zlecenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.ID);
            return View(zlecenie);
        }

        // GET: /Zlecenie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            return View(zlecenie);
        }

        // POST: /Zlecenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            db.Zlecenie.Remove(zlecenie);
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
