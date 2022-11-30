using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS.Models;

namespace SIS.Controllers
{
    
    public class SoldController : Controller
    {
        // GET: Sold

        public ActionResult Index()
        {
            using (SISEntities sis = new SISEntities())
            {

                return View(sis.SoldProducts.ToList());
            }
            
        }

        [HttpPost]
        public ActionResult Index(SoldProduct SP, Billing bill)
        {
            using (SISEntities sis = new SISEntities())
            {
                sis.SoldProducts.Where(x => bill.SelectedProducts == SP.ProductName).FirstOrDefault();
                
                sis.SaveChanges();
                
            }
            return View("Index");
        }
        
    }
}
