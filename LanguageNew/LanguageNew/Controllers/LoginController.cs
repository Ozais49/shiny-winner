using LanguageNew.DAL;
using LanguageNew.Models;
using LanguageNew.Repo;
using LanguageNew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LanguageNew.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View(new UserViewModel());
            else
                return RedirectToAction("Index", "Admin");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserViewModel model,string ReturnUrl)
        {
            List<string> errors = new List<string>();
       
                try
                {
                    IUser userrepo = new User();
                    if (ModelState.IsValid)
                    {
                        UserTable userobj = new UserTable();
                        userobj.Username = model.Username;
                        userobj.Password = model.Password;
                        int retval = userrepo.validateUser(userobj);
                        if (retval == 98)
                            ModelState.AddModelError("login", "User is blocked");
                        else if (retval == 99)
                        {
                            //deduct login count

                            ModelState.AddModelError("login", "invalid username or password.");
                        }
                        else if (retval == 0)
                        {
                            userrepo.insertLoginSuccess(model.Username, "");
                            FormsAuthentication.SetAuthCookie(model.Username, false);
                            return RedirectToAction("Index", "Admin");
                        }

                    }
                    foreach (var item in ModelState.Where(x => x.Value.Errors.Any()))
                    {
                        errors.Add(item.Value.Errors.FirstOrDefault().ErrorMessage);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            
        
            if (errors.Count > 0)
                TempData["Errors"] = errors;

            return View(model);
        }
    }
}