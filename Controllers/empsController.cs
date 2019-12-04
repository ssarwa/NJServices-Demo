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
    public class empsController : Controller
    {
        private njdbEntities db = new njdbEntities();

        // GET: emps
        public ActionResult Index()
        {
            var emps = db.emps.Include(e => e.dept);
            return View(emps.ToList());
        }

        // GET: emps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp emp = db.emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // GET: emps/Create
        public ActionResult Create()
        {
            ViewBag.deptno = new SelectList(db.depts, "deptno", "dname");
            return View();
        }

        // POST: emps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empno,ename,job,mgr,hiredate,sal,comm,deptno")] emp emp)
        {
            if (ModelState.IsValid)
            {
                db.emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.deptno = new SelectList(db.depts, "deptno", "dname", emp.deptno);
            return View(emp);
        }

        // GET: emps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp emp = db.emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            ViewBag.deptno = new SelectList(db.depts, "deptno", "dname", emp.deptno);
            return View(emp);
        }

        // POST: emps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empno,ename,job,mgr,hiredate,sal,comm,deptno")] emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deptno = new SelectList(db.depts, "deptno", "dname", emp.deptno);
            return View(emp);
        }

        // GET: emps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp emp = db.emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emp emp = db.emps.Find(id);
            db.emps.Remove(emp);
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
