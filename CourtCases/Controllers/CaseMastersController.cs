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
    public class CaseMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CaseMasters
        public ActionResult Index()
        {
            var caseMasters = db.CaseMasters.Include(c => c.JudgeMasters).Include(c => c.LawyerMaster).Include(c => c.Parties);
            return View(caseMasters.ToList());
        }

        // GET: CaseMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMaster caseMaster = db.CaseMasters.Find(id);
            if (caseMaster == null)
            {
                return HttpNotFound();
            }
            return View(caseMaster);
        }

        // GET: CaseMasters/Create
        public ActionResult Create()
        {
            ViewBag.JudgeMastersID = new SelectList(db.JudgeMasters, "ID", "JudgeName");
            ViewBag.LawyerMasterID = new SelectList(db.LawyerMasters, "ID", "LawyerName");
            ViewBag.PartiesID = new SelectList(db.Parties, "ID", "ApplicantName");
            return View();
        }

        // POST: CaseMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JudgeMastersID,PartiesID,LawyerMasterID,CaseName,Date,Type")] CaseMaster caseMaster)
        {
            if (ModelState.IsValid)
            {
                db.CaseMasters.Add(caseMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JudgeMastersID = new SelectList(db.JudgeMasters, "ID", "JudgeName", caseMaster.JudgeMastersID);
            ViewBag.LawyerMasterID = new SelectList(db.LawyerMasters, "ID", "LawyerName", caseMaster.LawyerMasterID);
            ViewBag.PartiesID = new SelectList(db.Parties, "ID", "ApplicantName", caseMaster.PartiesID);
            return View(caseMaster);
        }

        // GET: CaseMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMaster caseMaster = db.CaseMasters.Find(id);
            if (caseMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.JudgeMastersID = new SelectList(db.JudgeMasters, "ID", "JudgeName", caseMaster.JudgeMastersID);
            ViewBag.LawyerMasterID = new SelectList(db.LawyerMasters, "ID", "LawyerName", caseMaster.LawyerMasterID);
            ViewBag.PartiesID = new SelectList(db.Parties, "ID", "ApplicantName", caseMaster.PartiesID);
            return View(caseMaster);
        }

        // POST: CaseMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JudgeMastersID,PartiesID,LawyerMasterID,CaseName,Date,Type")] CaseMaster caseMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JudgeMastersID = new SelectList(db.JudgeMasters, "ID", "JudgeName", caseMaster.JudgeMastersID);
            ViewBag.LawyerMasterID = new SelectList(db.LawyerMasters, "ID", "LawyerName", caseMaster.LawyerMasterID);
            ViewBag.PartiesID = new SelectList(db.Parties, "ID", "ApplicantName", caseMaster.PartiesID);
            return View(caseMaster);
        }

        // GET: CaseMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMaster caseMaster = db.CaseMasters.Find(id);
            if (caseMaster == null)
            {
                return HttpNotFound();
            }
            return View(caseMaster);
        }

        // POST: CaseMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseMaster caseMaster = db.CaseMasters.Find(id);
            db.CaseMasters.Remove(caseMaster);
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
