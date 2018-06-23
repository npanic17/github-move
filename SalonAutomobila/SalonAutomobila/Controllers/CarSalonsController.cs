using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonAutomobila.Models;
using SalonAutomobila.ViewModel;

namespace SalonAutomobila.Controllers
{
    public class CarSalonsController : Controller
    {
        private SalonContext db = new SalonContext();

        // GET: CarSalons
        public ActionResult Index()
        {
            return View(db.CarSalon.ToList());
        }

        // GET: CarSalons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSalon carSalon = db.CarSalon.Find(id);
            SalonListsCarsContractsViewModel vm = new SalonListsCarsContractsViewModel();
            vm.CarSalons = carSalon;
            vm.ListCars = db.Cars.Include(c=>c.Manufacturer).Where(m => m.CarSalonId == id).ToList();
            vm.ListContracts = db.Contract.Where(m => m.CarSalonId == id).ToList();
            if (carSalon == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: CarSalons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarSalons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PIB,Name,Country,City,Address")] CarSalon carSalon)
        {
            if (ModelState.IsValid)
            {
                db.CarSalon.Add(carSalon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carSalon);
        }

        // GET: CarSalons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSalon carSalon = db.CarSalon.Find(id);
            if (carSalon == null)
            {
                return HttpNotFound();
            }
            return View(carSalon);
        }

        // POST: CarSalons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PIB,Name,Country,City,Address")] CarSalon carSalon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carSalon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carSalon);
        }

        // GET: CarSalons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSalon carSalon = db.CarSalon.Find(id);
            if (carSalon == null)
            {
                return HttpNotFound();
            }
            return View(carSalon);
        }

        // POST: CarSalons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarSalon carSalon = db.CarSalon.Find(id);
            db.CarSalon.Remove(carSalon);
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
