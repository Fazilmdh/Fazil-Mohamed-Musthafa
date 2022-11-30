using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS.Models;

namespace SIS.Controllers
{
    
    public class ProductMasterController : Controller
    {
        // GET: ProductMaster
        public ActionResult Index()
        {
            using(SISEntities sis = new SISEntities())
            {
                return View(sis.ProductMasters.ToList());
            }
            
        }

       

        // POST: ProductMaster/Index
        [HttpPost]
        public ActionResult Index(int id, ProductMaster PM, SoldProduct SP)
        {
            try
            {
                using (SISEntities sis = new SISEntities())
                {
                    PM.Available = PM.MaxQuantity - SP.QuantitySold;
                    sis.Entry(PM).State = EntityState.Modified;
                    sis.SaveChanges();
                    
                    // TODO: Add update logic here
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
