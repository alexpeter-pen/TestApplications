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
    [Authorize]
    public class TodoItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TodoItems
        public ActionResult Index()
        {
            var todoItems = db.TodoItems.OrderBy(td => td.Title).Include(t => t.PlanItem);
            return View(todoItems.ToList());
        }

        // GET: TodoItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = db.TodoItems.Find(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }

        // GET: TodoItems/Create
        public ActionResult Create()
        {
            ViewBag.PlanItemId = new SelectList(db.PlanItems, "Id", "Title");
            return View();
        }

        // GET: TodoItems/CreateItem/4
        public ActionResult CreateItem(int? id)
        {
            ViewBag.PlanItemId = new SelectList(db.PlanItems, "Id", "Title", id);
            return View("Create", id == null ? null : new TodoItem { PlanItemId = id.Value });
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,PlanItemId")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                db.TodoItems.Add(todoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlanItemId = new SelectList(db.PlanItems, "Id", "Title", todoItem.PlanItemId);
            return View(todoItem);
        }

        // GET: TodoItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = db.TodoItems.Find(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlanItemId = new SelectList(db.PlanItems, "Id", "Title", todoItem.PlanItemId);
            return View(todoItem);
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PlanItemId")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlanItemId = new SelectList(db.PlanItems, "Id", "Title", todoItem.PlanItemId);
            return View(todoItem);
        }

        // GET: TodoItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoItem todoItem = db.TodoItems.Find(id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoItem todoItem = db.TodoItems.Find(id);
            db.TodoItems.Remove(todoItem);
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
