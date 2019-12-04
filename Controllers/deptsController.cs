using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NJServices_Demo.Models;

namespace NJServices_Demo.Controllers
{
    public class deptsController : Controller
    {
        private njdbEntities db = new njdbEntities();

        // GET: depts
        public ActionResult Index()
        {
            return View(db.depts.ToList());
        }

        // GET: depts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dept dept = db.depts.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // GET: depts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: depts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "deptno,dname,loc")] dept dept)
        {
            if (ModelState.IsValid)
            {
                db.depts.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dept);
        }

        // GET: depts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dept dept = db.depts.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // POST: depts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "deptno,dname,loc")] dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        // GET: depts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dept dept = db.depts.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // POST: depts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dept dept = db.depts.Find(id);
            db.depts.Remove(dept);
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
