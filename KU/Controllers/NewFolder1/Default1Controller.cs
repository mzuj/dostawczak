using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KU.Models;

namespace KU.Controllers.NewFolder1
{
    public class Default1Controller : Controller
    {
        private ZlecenieEntities db = new ZlecenieEntities();

        // GET: /Default1/
        public ActionResult Index()
        {
            var zlecenie = db.Zlecenie.Include(z => z.AspNetUsers).Include(z => z.KanalSprzedazySet).Include(z => z.OknoWyjazduSet).Include(z => z.PowodOdrzucenia).Include(z => z.PowodPrzelozeniaSet).Include(z => z.RodzajOpakowania).Include(z => z.RodzajZleceniaSet).Include(z => z.StatusZlecenie).Include(z => z.Zawartosc);
            return View(zlecenie.ToList());
        }

        // GET: /Default1/Details/5
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

        // GET: /Default1/Create
        public ActionResult Create()
        {
            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.KanalSprzedazyId = new SelectList(db.KanalSprzedazySet, "Id", "Nazwa");
            ViewBag.OknoWyjazduId = new SelectList(db.OknoWyjazduSet, "Id", "Id");
            ViewBag.PowodOdrzuceniaId = new SelectList(db.PowodOdrzucenia, "Id", "Powód");
            ViewBag.PowodPrzelozeniaId = new SelectList(db.PowodPrzelozeniaSet, "Id", "Powód");
            ViewBag.RodzajOpakowaniaId = new SelectList(db.RodzajOpakowania, "Id", "Rodzaj");
            ViewBag.RodzajZleceniaId = new SelectList(db.RodzajZleceniaSet, "Id", "Rodzaj");
            ViewBag.Status = new SelectList(db.StatusZlecenie, "Id", "Nazwa");
            ViewBag.ZawartoscId = new SelectList(db.Zawartosc, "Id", "Zawartość");
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ZlecenieID,Miejsce_nadania,Miejsce_dostawy,Odbiorca,Zleceniodawca,Ilosc_opakowan,Materialy_niebezpieczne,Pobranie_za_przesylke,Priorytet,Kurier,Status,Komentarz_kuriera,Komentarz_nadawcy,RodzajOpakowaniaId,ZawartoscId,PowodOdrzuceniaId,PowodPrzelozeniaId,RodzajZleceniaId,OknoWyjazduId,Ilosc_nieudanych_prob_realizacji,Data_nasepnej_proby,KanalSprzedazyId")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Zlecenie.Add(zlecenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.Kurier);
            ViewBag.KanalSprzedazyId = new SelectList(db.KanalSprzedazySet, "Id", "Nazwa", zlecenie.KanalSprzedazyId);
            ViewBag.OknoWyjazduId = new SelectList(db.OknoWyjazduSet, "Id", "Id", zlecenie.OknoWyjazduId);
            ViewBag.PowodOdrzuceniaId = new SelectList(db.PowodOdrzucenia, "Id", "Powód", zlecenie.PowodOdrzuceniaId);
            ViewBag.PowodPrzelozeniaId = new SelectList(db.PowodPrzelozeniaSet, "Id", "Powód", zlecenie.PowodPrzelozeniaId);
            ViewBag.RodzajOpakowaniaId = new SelectList(db.RodzajOpakowania, "Id", "Rodzaj", zlecenie.RodzajOpakowaniaId);
            ViewBag.RodzajZleceniaId = new SelectList(db.RodzajZleceniaSet, "Id", "Rodzaj", zlecenie.RodzajZleceniaId);
            ViewBag.Status = new SelectList(db.StatusZlecenie, "Id", "Nazwa", zlecenie.Status);
            ViewBag.ZawartoscId = new SelectList(db.Zawartosc, "Id", "Zawartość", zlecenie.ZawartoscId);
            return View(zlecenie);
        }

        // GET: /Default1/Edit/5
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
            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.Kurier);
            ViewBag.KanalSprzedazyId = new SelectList(db.KanalSprzedazySet, "Id", "Nazwa", zlecenie.KanalSprzedazyId);
            ViewBag.OknoWyjazduId = new SelectList(db.OknoWyjazduSet, "Id", "Id", zlecenie.OknoWyjazduId);
            ViewBag.PowodOdrzuceniaId = new SelectList(db.PowodOdrzucenia, "Id", "Powód", zlecenie.PowodOdrzuceniaId);
            ViewBag.PowodPrzelozeniaId = new SelectList(db.PowodPrzelozeniaSet, "Id", "Powód", zlecenie.PowodPrzelozeniaId);
            ViewBag.RodzajOpakowaniaId = new SelectList(db.RodzajOpakowania, "Id", "Rodzaj", zlecenie.RodzajOpakowaniaId);
            ViewBag.RodzajZleceniaId = new SelectList(db.RodzajZleceniaSet, "Id", "Rodzaj", zlecenie.RodzajZleceniaId);
            ViewBag.Status = new SelectList(db.StatusZlecenie, "Id", "Nazwa", zlecenie.Status);
            ViewBag.ZawartoscId = new SelectList(db.Zawartosc, "Id", "Zawartość", zlecenie.ZawartoscId);
            return View(zlecenie);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ZlecenieID,Miejsce_nadania,Miejsce_dostawy,Odbiorca,Zleceniodawca,Ilosc_opakowan,Materialy_niebezpieczne,Pobranie_za_przesylke,Priorytet,Kurier,Status,Komentarz_kuriera,Komentarz_nadawcy,RodzajOpakowaniaId,ZawartoscId,PowodOdrzuceniaId,PowodPrzelozeniaId,RodzajZleceniaId,OknoWyjazduId,Ilosc_nieudanych_prob_realizacji,Data_nasepnej_proby,KanalSprzedazyId")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zlecenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.Kurier);
            ViewBag.KanalSprzedazyId = new SelectList(db.KanalSprzedazySet, "Id", "Nazwa", zlecenie.KanalSprzedazyId);
            ViewBag.OknoWyjazduId = new SelectList(db.OknoWyjazduSet, "Id", "Id", zlecenie.OknoWyjazduId);
            ViewBag.PowodOdrzuceniaId = new SelectList(db.PowodOdrzucenia, "Id", "Powód", zlecenie.PowodOdrzuceniaId);
            ViewBag.PowodPrzelozeniaId = new SelectList(db.PowodPrzelozeniaSet, "Id", "Powód", zlecenie.PowodPrzelozeniaId);
            ViewBag.RodzajOpakowaniaId = new SelectList(db.RodzajOpakowania, "Id", "Rodzaj", zlecenie.RodzajOpakowaniaId);
            ViewBag.RodzajZleceniaId = new SelectList(db.RodzajZleceniaSet, "Id", "Rodzaj", zlecenie.RodzajZleceniaId);
            ViewBag.Status = new SelectList(db.StatusZlecenie, "Id", "Nazwa", zlecenie.Status);
            ViewBag.ZawartoscId = new SelectList(db.Zawartosc, "Id", "Zawartość", zlecenie.ZawartoscId);
            return View(zlecenie);
        }

        // GET: /Default1/Delete/5
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

        // POST: /Default1/Delete/5
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
