using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DefectServer.Models;

namespace DefectServer.Controllers
{
    public class DefectsController : Controller
    {
        private DefectServerContext db = new DefectServerContext();

        // GET: Defects
        public ActionResult Index()
        {
            var defects = db.Defects.Include(d => d.Job);
            return View(defects.ToList());
        }

        // GET: Defects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defect defect = db.Defects.Find(id);
            if (defect == null)
            {
                return HttpNotFound();
            }
            return View(defect);
        }

        // GET: Defects/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Description");
            return View();
        }

        // POST: Defects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Description,ImageName,ImageBase64,JobId,DateCreated,DateModified")] Defect defect)
        {
            if (ModelState.IsValid)
            {
                db.Defects.Add(defect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Description", defect.JobId);
            return View(defect);
        }

        // GET: Defects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defect defect = db.Defects.Find(id);
            if (defect == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Description", defect.JobId);
            return View(defect);
        }

        // POST: Defects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Description,ImageName,ImageBase64,JobId,DateCreated,DateModified")] Defect defect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Description", defect.JobId);
            return View(defect);
        }

        // GET: Defects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defect defect = db.Defects.Find(id);
            if (defect == null)
            {
                return HttpNotFound();
            }
            return View(defect);
        }

        // POST: Defects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Defect defect = db.Defects.Find(id);
            db.Defects.Remove(defect);
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
