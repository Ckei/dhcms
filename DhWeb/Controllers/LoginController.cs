using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhWeb.Models;

namespace DhWeb.Controllers
{
    public class LoginController : Controller
    {
        LoginViewmodel model = new LoginViewmodel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string loginUsername, string loginPassword)
        {
            if (model.IsUserAdmin(loginUsername, loginPassword))
            {
                return RedirectToAction("Index","SiteOptions");
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}