using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS.Models;
using System.Data.Entity;

namespace SIS.Controllers
{
    
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (SISEntities sis = new SISEntities())
            {
                return View(sis.CustomerMasters.ToList());
            }
                
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (SISEntities sis = new SISEntities())
            {
                return View(sis.CustomerMasters.Where(x => x.C_ID == id).FirstOrDefault());
            }
            
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerMaster cust)
        {
            try
            {
                using (SISEntities sis = new SISEntities())
                {
                    sis.CustomerMasters.Add(cust);
                    sis.SaveChanges();
                    TempData["SuccessMessage"] = "Saved Successfully";
                }
                    // TODO: Add insert logic here

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
            using (SISEntities sis = new SISEntities())
            {
                return View(sis.CustomerMasters.Where(x => x.C_ID == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerMaster cust)
        {
            try
            {
                using (SISEntities sis = new SISEntities())
                {
                    sis.Entry(cust).State = EntityState.Modified;
                    sis.SaveChanges();
                    TempData["SuccessMessage"] = "Updated Successfully";

                }
                    // TODO: Add update logic here

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
            using (SISEntities sis = new SISEntities())
            {
                return View(sis.CustomerMasters.Where(x => x.C_ID == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerMaster cust)
        {
            try
            {
                using (SISEntities sis = new SISEntities())
                {
                    cust = sis.CustomerMasters.Where(x => x.C_ID == id).FirstOrDefault();
                    sis.CustomerMasters.Remove(cust);
                    sis.SaveChanges();

                    TempData["SuccessMessage"] = "Deleted Successfully";
                }
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
