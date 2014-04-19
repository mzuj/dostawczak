using System;
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
    public class IKController : Controller
    {
        private ZlecenieEntities db = new ZlecenieEntities();
        CommissionStatusHelper errandStatusHelper = new CommissionStatusHelper();

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
            errandStatusHelper.SetCommissionStatus("Zrealizowane", id);
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
            errandStatusHelper.SetCommissionStatus("Do późniejszej realizacji", id);
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
            errandStatusHelper.SetCommissionStatus("Brak możliwośc realizacji", id);
            return RedirectToAction("Index", "Zlecenie");
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
