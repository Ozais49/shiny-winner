using LanguageNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LanguageNew.Controllers
{
    public class AdminController : Controller
    {
        // GET: Landing
        [Authorize]
        //login
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
         
            return View(new UserTable());
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserTable model)
        {

            return View();
        }
        

    }
}