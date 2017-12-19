using DefectServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefectServer.Controllers
{
    public class HomeController : Controller
    {
        private DefectServerContext db;

        public HomeController()
        {
            db = new DefectServerContext();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Defects";

            return View();
        }
    }
}
