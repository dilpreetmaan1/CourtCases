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
    public class JudgeMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JudgeMasters
        public ActionResult Index()
        {
            return View(db.JudgeMasters.ToList());
        }

        // GET: JudgeMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeMasters judgeMasters = db.JudgeMasters.Find(id);
            if (judgeMasters == null)
            {
                return HttpNotFound();
            }
            return View(judgeMasters);
        }

        // GET: JudgeMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JudgeMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JudgeName,Speciality,Age")] JudgeMasters judgeMasters)
        {
            if (ModelState.IsValid)
            {
                db.JudgeMasters.Add(judgeMasters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(judgeMasters);
        }

        // GET: JudgeMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeMasters judgeMasters = db.JudgeMasters.Find(id);
            if (judgeMasters == null)
            {
                return HttpNotFound();
            }
            return View(judgeMasters);
        }

        // POST: JudgeMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JudgeName,Speciality,Age")] JudgeMasters judgeMasters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(judgeMasters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(judgeMasters);
        }

        // GET: JudgeMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeMasters judgeMasters = db.JudgeMasters.Find(id);
            if (judgeMasters == null)
            {
                return HttpNotFound();
            }
            return View(judgeMasters);
        }

        // POST: JudgeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JudgeMasters judgeMasters = db.JudgeMasters.Find(id);
            db.JudgeMasters.Remove(judgeMasters);
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
