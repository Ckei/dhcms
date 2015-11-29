using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DhWeb.Models;

namespace DhWeb.Controllers
{
    public class HomeController : Controller
    {
        HomeViewmodel model = new HomeViewmodel();

        // GET: Home
        public ActionResult Index()
        {
            return View(model);
        }
    }
}