using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonAutomobila.Models;

namespace SalonAutomobila.Controllers
{
    public class ContractsController : Controller
    {
        private SalonContext db = new SalonContext();

        // GET: Contracts
        public ActionResult Index()
        {
            var contract = db.Contract.Include(c => c.CarSalon).Include(c => c.Manufacturer);
            return View(contract.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create(int? id)
        {
            ViewBag.id = id;
            ViewBag.CarSalonId = db.CarSalon.Find(id).Name;
            //var ugovori=db.Contract
            //var example = db.Contract.Join(
            //    db.Manufacturer,
            //    contract => contract.ManufacturerId,
            //    manufacturer => manufacturer.Id,
            //    (contract, manufacturer) =>
            //    new {
            //        contract.CarSalonId,
            //        manufacturer.Id,
            //        manufacturer.Name,
            //    }).Where(m=>m.CarSalonId != id).ToList();
            //var my = from m in db.Contract
            //         join n in db.Manufacturer on m.ManufacturerId equals n.Id
            //         where m.CarSalonId == id select m;

            var diff = from c in db.Contract
                       where !(from m in db.Contract
                               join n in db.Manufacturer on m.ManufacturerId equals n.Id
                               where m.CarSalonId == id) select c;
                       


            //var my = db.Contract
            //    .Join(db.Manufacturer,
            //    c=> c.ManufacturerId,
            //    m=>m.Id, 
            //    (c,m)=> new { c.CarSalonId,m.Name,m.Id})
            //    .Where(ContractManufacturer => ContractManufacturer.CarSalonId==id);
            //var all = db.Contract
            //    .Join(db.Manufacturer,
            //    c => c.ManufacturerId,
            //    m => m.Id,
            //    (c, m) => new { m.Name });
            //var diff = my.Except(all,d=>d.Name);

                       // ViewBag.ManufacturerId = new SelectList(example, "Id", "Name");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CarSalonId,ManufacturerId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contract.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Details", "CarSalons", new { id = contract.CarSalonId });
            }

            ViewBag.CarSalonId = new SelectList(db.CarSalon, "Id", "PIB", contract.CarSalonId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturer, "Id", "Name", contract.ManufacturerId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarSalonId = new SelectList(db.CarSalon, "Id", "PIB", contract.CarSalonId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturer, "Id", "Name", contract.ManufacturerId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CarSalonId,ManufacturerId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarSalonId = new SelectList(db.CarSalon, "Id", "PIB", contract.CarSalonId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturer, "Id", "Name", contract.ManufacturerId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contract.Find(id);
            db.Contract.Remove(contract);
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
