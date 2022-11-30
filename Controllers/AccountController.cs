using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS.Models;
using System.Web.Security;

namespace SIS.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(EmployeeMaster EM)
        {
            using (SISEntities sis = new SISEntities())
            {
                bool isValid = sis.EmployeeMasters.Any(x => x.UserName == EM.UserName && x.Password == EM.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(EM.UserName, false);
                    return RedirectToAction("Index", "ProductMaster");
                }
                ModelState.AddModelError("", "Invalid UserName and Password");
                return View();
            }
        }


        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(EmployeeMaster EM)
        {
            using (SISEntities sis = new SISEntities())
            {
                sis.EmployeeMasters.Add(EM);
                sis.SaveChanges();
                
            }
            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}