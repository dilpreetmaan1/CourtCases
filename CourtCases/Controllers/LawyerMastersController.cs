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
    public class LawyerMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LawyerMasters
        public ActionResult Index()
        {
            return View(db.LawyerMasters.ToList());
        }

        // GET: LawyerMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerMaster lawyerMaster = db.LawyerMasters.Find(id);
            if (lawyerMaster == null)
            {
                return HttpNotFound();
            }
            return View(lawyerMaster);
        }

        // GET: LawyerMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LawyerMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LawyerName,Address,Mobile,Email")] LawyerMaster lawyerMaster)
        {
            if (ModelState.IsValid)
            {
                db.LawyerMasters.Add(lawyerMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lawyerMaster);
        }

        // GET: LawyerMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerMaster lawyerMaster = db.LawyerMasters.Find(id);
            if (lawyerMaster == null)
            {
                return HttpNotFound();
            }
            return View(lawyerMaster);
        }

        // POST: LawyerMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LawyerName,Address,Mobile,Email")] LawyerMaster lawyerMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawyerMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lawyerMaster);
        }

        // GET: LawyerMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerMaster lawyerMaster = db.LawyerMasters.Find(id);
            if (lawyerMaster == null)
            {
                return HttpNotFound();
            }
            return View(lawyerMaster);
        }

        // POST: LawyerMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LawyerMaster lawyerMaster = db.LawyerMasters.Find(id);
            db.LawyerMasters.Remove(lawyerMaster);
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
