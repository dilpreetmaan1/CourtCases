using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourtCases.Models;

namespace CourtCases.Controllers
{
    public class HearingMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HearingMasters
        public ActionResult Index()
        {
            var hearingMasters = db.HearingMasters.Include(h => h.CaseMaster);
            return View(hearingMasters.ToList());
        }

        // GET: HearingMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingMaster hearingMaster = db.HearingMasters.Find(id);
            if (hearingMaster == null)
            {
                return HttpNotFound();
            }
            return View(hearingMaster);
        }

        // GET: HearingMasters/Create
        public ActionResult Create()
        {
            ViewBag.CaseMasterID = new SelectList(db.CaseMasters, "ID", "CaseName");
            return View();
        }

        // POST: HearingMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CaseMasterID,CurrentDate,NextDate")] HearingMaster hearingMaster)
        {
            if (ModelState.IsValid)
            {
                db.HearingMasters.Add(hearingMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseMasterID = new SelectList(db.CaseMasters, "ID", "CaseName", hearingMaster.CaseMasterID);
            return View(hearingMaster);
        }

        // GET: HearingMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingMaster hearingMaster = db.HearingMasters.Find(id);
            if (hearingMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseMasterID = new SelectList(db.CaseMasters, "ID", "CaseName", hearingMaster.CaseMasterID);
            return View(hearingMaster);
        }

        // POST: HearingMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CaseMasterID,CurrentDate,NextDate")] HearingMaster hearingMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hearingMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseMasterID = new SelectList(db.CaseMasters, "ID", "CaseName", hearingMaster.CaseMasterID);
            return View(hearingMaster);
        }

        // GET: HearingMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingMaster hearingMaster = db.HearingMasters.Find(id);
            if (hearingMaster == null)
            {
                return HttpNotFound();
            }
            return View(hearingMaster);
        }

        // POST: HearingMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HearingMaster hearingMaster = db.HearingMasters.Find(id);
            db.HearingMasters.Remove(hearingMaster);
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
