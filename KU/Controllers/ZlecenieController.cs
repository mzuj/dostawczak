﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KU.Models;
using KU.Logic;

namespace KU.Controllers
{
    public class ZlecenieController : Controller
    {
        private ZlecenieEntities db = new ZlecenieEntities();
        ErrandStatusHelper errandStatusHelper = new ErrandStatusHelper();

        // GET: /Zlecenie/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var idZleceniaOdbioru = errandStatusHelper.GetStatusIdByName("W trakcie realizacji przez kuriera - odbieranie");
                var idZleceniaDostawy = errandStatusHelper.GetStatusIdByName("W trakcie realizacji przez kuriera - dostarczanie");

                var zlecenie = from s in db.Zlecenie
                               where s.Status.Equals(idZleceniaDostawy) || s.Status.Equals(idZleceniaOdbioru) 
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

        [HttpGet]
        public ActionResult Completed(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Completed(int id)
        {
            errandStatusHelper.SetErrandStatus("Zrealizowane", id);
            return RedirectToAction("Index","Zlecenie");
        }

        [HttpGet]
        public ActionResult DelayCompletion(int? id)
        {
            ViewBag.PowodPrzelozeniaId = new SelectList(db.PowodPrzelozeniaSet, "Id", "Powód");
            return View();
        }
        [HttpPost]
        public ActionResult DelayCompletion(int id, int? PowodPrzelozeniaId)
        {
            var zle = db.Zlecenie.Find(id);
            zle.PowodPrzelozeniaId = PowodPrzelozeniaId;
            db.SaveChanges();
            errandStatusHelper.SetErrandStatus("Do późniejszej realizacji", id);
            return RedirectToAction("Index", "Zlecenie");
        }

        [HttpGet]
        public ActionResult UnableToComplete(int? id)
        {
            ViewBag.PowodOdrzuceniaId = new SelectList(db.PowodOdrzucenia, "Id", "Powód");
            return View();
        }
        [HttpPost]
        public ActionResult UnableToComplete(int id, int? PowodOdrzuceniaId)
        {
            var zle = db.Zlecenie.Find(id);
            zle.PowodOdrzuceniaId = PowodOdrzuceniaId;
            db.SaveChanges();
            errandStatusHelper.SetErrandStatus("Brak możliwośc realizacji", id);
            return RedirectToAction("Index", "Zlecenie");
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

        public ActionResult Create()
        {
            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.Status = new SelectList(db.StatusZlecenie, "Id", "Nazwa");
            ViewBag.PowodOdrzuceniaId = new SelectList(db.PowodOdrzucenia, "Id", "Powód");
            ViewBag.PowodPrzelozeniaId = new SelectList(db.PowodPrzelozeniaSet, "Id", "Powód");
            ViewBag.RodzajOpakowaniaId = new SelectList(db.RodzajOpakowania, "Id", "Rodzaj");
            ViewBag.ZawartoscId = new SelectList(db.Zawartosc, "Id", "Zawartość");
            ViewBag.RodzajZleceniaId = new SelectList(db.RodzajZleceniaSet, "Id", "Rodzaj");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZlecenieID,Miejsce_nadania,Miejsce_dostawy,Odbiorca,Zleceniodawca,Ilosc_opakowan,Materialy_niebezpieczne,Pobranie_za_przesylke,Priorytet,Kurier,Status,Komentarz_kuriera,Komentarz_nadawcy,RodzajOpakowaniaId,ZawartoscId,PowodOdrzuceniaId,PowodPrzelozeniaId,RodzajZleceniaId")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Zlecenie.Add(zlecenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kurier = new SelectList(db.AspNetUsers, "Id", "UserName", zlecenie.Kurier);
            ViewBag.Status = new SelectList(db.StatusZlecenie, "Id", "Nazwa", zlecenie.Status);
            ViewBag.PowodOdrzuceniaId = new SelectList(db.PowodOdrzucenia, "Id", "Powód", zlecenie.PowodOdrzuceniaId);
            ViewBag.PowodPrzelozeniaId = new SelectList(db.PowodPrzelozeniaSet, "Id", "Powód", zlecenie.PowodPrzelozeniaId);
            ViewBag.RodzajOpakowaniaId = new SelectList(db.RodzajOpakowania, "Id", "Rodzaj", zlecenie.RodzajOpakowaniaId);
            ViewBag.ZawartoscId = new SelectList(db.Zawartosc, "Id", "Zawartość", zlecenie.ZawartoscId);
            ViewBag.RodzajZleceniaId = new SelectList(db.RodzajZleceniaSet, "Id", "Rodzaj", zlecenie.RodzajZleceniaId);
            return View(zlecenie);
        }
    }
}
