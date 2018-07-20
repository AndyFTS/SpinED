using SpinED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpinED.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            Session["Signedin"] = true;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login( LoginViewModel model)
        {

            if(model.username =="colby@spined.ca" && model.password == "spined")
            {
                Session["Signedin"] = true; 
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Unable to authenticate";
                return RedirectToAction("Login", "Home");
            }
         
           
        }
        public ActionResult Logout()
        {
            Session["Signedin"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}