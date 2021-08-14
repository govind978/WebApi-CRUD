using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud.Models;

namespace MvcCrud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using(DBModels db = new DBModels())
            {
                return View(db.Employees.ToList());
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                using(DBModels db = new DBModels())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                using(DBModels db = new DBModels())
                {
                    db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee )
        {
            try
            {
                // TODO: Add delete logic here
                using(DBModels db = new DBModels())
                {
                    employee = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
