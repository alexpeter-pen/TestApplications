using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class PlanItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanItems
        public ActionResult Index()
        {
            return View(db.PlanItems.ToList());
        }

        // GET: PlanItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanItem planItem = db.PlanItems.Find(id);
            if (planItem == null)
            {
                return HttpNotFound();
            }
            return View(planItem);
        }

        // GET: PlanItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] PlanItem planItem)
        {
            if (ModelState.IsValid)
            {
                db.PlanItems.Add(planItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planItem);
        }

        // GET: PlanItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanItem planItem = db.PlanItems.Find(id);
            if (planItem == null)
            {
                return HttpNotFound();
            }
            return View(planItem);
        }

        // POST: PlanItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] PlanItem planItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planItem);
        }

        // GET: PlanItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanItem planItem = db.PlanItems.Find(id);
            if (planItem == null)
            {
                return HttpNotFound();
            }
            return View(planItem);
        }

        // POST: PlanItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanItem planItem = db.PlanItems.Find(id);
            db.PlanItems.Remove(planItem);
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
