using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackerOlympics.Login.Models;

namespace HackerOlympics.Login.Controllers
{
    public class StartupController : Controller
    {
        //
        // GET: /Startup/
        public ActionResult Index()
        {
            UrbanStartup startup = new UrbanStartup();
            startup.GetRandomName();
            return View(startup);
        }

        
    }
}
