using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackerOlympics.Login.Models;

namespace HackerOlympics.Login.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Login/

        //public ActionResult Index()
        //{
        //    GeneratePassword password = new GeneratePassword();
        //    return View(password);
        //}

        public ActionResult Index(string name, string password)
        {

            GeneratePassword pass = new GeneratePassword();
            if (name != null)
            {
                if (password == null)
                {
                    pass.GeneratePass(name);
                }
                else
                {
                    pass.Login(true, password);
                }
            }

            return View(pass);
        }
    }
}
