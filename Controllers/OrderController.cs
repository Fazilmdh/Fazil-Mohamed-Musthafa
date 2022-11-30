using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS.Models;

namespace SIS.Controllers
{
    
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {

            using (SISEntities sis = new SISEntities())
            {
                return View(sis.Billings.ToList());
            }
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var list1 = new List<string>() {"Chair", "Cubboard", "Wardrob", "bed", "door", "Modularkitchen", "DinningTable", "Window", "Hanger", "RawMaterial" };
            ViewBag.list1 = list1;


            var list2 = new List<string>() { "Fazil", "Mohamed", "Musthafa", "HF", "xxx" };
            ViewBag.list2 = list2;


            var list3 = new List<string>() { "Cash", "Credit", "Netpay", "Gpay", "Card" };
            ViewBag.list3 = list3;

            



            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Billing bill)
        {

            using (SISEntities sis = new SISEntities())
            {
                sis.Billings.Add(bill);
                sis.SaveChanges();
                
            }
            // TODO: Add insert logic here

            return RedirectToAction("Index");



        }

       
    }
}
