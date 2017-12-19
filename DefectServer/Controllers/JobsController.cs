using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DefectServer.Models;
using DefectServer.ViewModel;

namespace DefectServer.Controllers
{
    public class JobsController : Controller
    {
        private DefectServerContext db = new DefectServerContext();

        public SelectList GetUsers()
        {
            List<SelectListItem> users = db.Users.OrderBy(n => n.SurName)
                .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = String.Concat(n.SurName.ToString(), ", ", n.FirstName.ToString() )}).ToList();
            //var userstip = new SelectListItem() { Value = null, Text = "--- select user ---" }; users.Insert(0, userstip);
            return new SelectList(users, "Value", "Text");
        }

        // GET: Jobs
        public ActionResult Index()
        {
            return View(db.Jobs.Include(i => i.JobUser).ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            JobViewModel jobviewmodel = new JobViewModel();
            jobviewmodel.job = new Job();
            jobviewmodel.users = GetUsers();
            return View(jobviewmodel);
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobViewModel jobViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.Find(jobViewModel.job.UserId);
                jobViewModel.job.JobUser = user;
                db.Jobs.Add(jobViewModel.job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            jobViewModel.users = GetUsers();
            return View(jobViewModel);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobViewModel jobviewmodel = new JobViewModel();
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            jobviewmodel.job = job;
            jobviewmodel.users = GetUsers();
            return View(jobviewmodel);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
