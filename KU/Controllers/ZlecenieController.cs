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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var zlecenie = from s in db.Zlecenie
                               select s;

                var zlecenieKuriera = zlecenie.Where(s => s.AspNetUsers.UserName.Contains(User.Identity.Name));
                var listaZlecen = zlecenieKuriera.OrderByDescending(s => s.Priorytet);

                return View(listaZlecen.ToList());
            }               
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
            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.Status = new SelectList(db.StatusZlecenie, "Id", "Nazwa");
            return View();
        }

        // POST: /Zlecenie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ZlecenieID,Miejsce_nadania,Miejsce_dostawy,Odbiorca,Zleceniodawca,Zawartosc,Ilosc_opakowan,Rodzaj_opakowan,Materialy_niebezpieczne,Pobranie_za_przesylke,Priorytet,Kategoria_zlecenia,Kurier, Status")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Zlecenie.Add(zlecenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.Kurier);
            ViewBag.Status = new SelectList(db.StatusZlecenie);
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
            ViewBag.ID = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.Kurier);
            return View(zlecenie);
        }

        // POST: /Zlecenie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ZlecenieID,Miejsce_nadania,Miejsce_dostawy,Odbiorca,Zleceniodawca,Zawartosc,Ilosc_opakowan,Rodzaj_opakowan,Materialy_niebezpieczne,Pobranie_za_przesylke,Priorytet,Kategoria_zlecenia,Kurier,Status")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zlecenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.Kurier);
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

        public ActionResult NavigateGMaps(long id)
        {
            var adress = db.Zlecenie.Find(id).Miejsce_dostawy;
            return Redirect("http://maps.google.com/maps?" + "q=" + adress);
        }
    }
}
