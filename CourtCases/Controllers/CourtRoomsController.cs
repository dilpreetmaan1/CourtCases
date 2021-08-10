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
    public class CourtRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourtRooms
        public ActionResult Index()
        {
            return View(db.CourtRooms.ToList());
        }

        // GET: CourtRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRooms courtRooms = db.CourtRooms.Find(id);
            if (courtRooms == null)
            {
                return HttpNotFound();
            }
            return View(courtRooms);
        }

        // GET: CourtRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoomNo")] CourtRooms courtRooms)
        {
            if (ModelState.IsValid)
            {
                db.CourtRooms.Add(courtRooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courtRooms);
        }

        // GET: CourtRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRooms courtRooms = db.CourtRooms.Find(id);
            if (courtRooms == null)
            {
                return HttpNotFound();
            }
            return View(courtRooms);
        }

        // POST: CourtRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoomNo")] CourtRooms courtRooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtRooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtRooms);
        }

        // GET: CourtRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRooms courtRooms = db.CourtRooms.Find(id);
            if (courtRooms == null)
            {
                return HttpNotFound();
            }
            return View(courtRooms);
        }

        // POST: CourtRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtRooms courtRooms = db.CourtRooms.Find(id);
            db.CourtRooms.Remove(courtRooms);
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
