using LanguageNew.DAL;
using LanguageNew.Models;
using LanguageNew.Repo;
using LanguageNew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageNew.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestion _Question;
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuestionViewModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(QuestionViewModel model) 
        {
            List<string> errors = new List<string>();
            try
            {
                _Question = new Question();
                if (ModelState.IsValid)
                {
                    if(model.Image != null)
                    {

                    }
                    Questions addquestion = new Questions();
                    addquestion.Question = model.Question;
                    addquestion.Option1 = model.Option1;
                    addquestion.Option2 = model.Option2;
                    addquestion.Option3 = model.Option3;
                    addquestion.Option4 = model.Option4;
                    addquestion.Status = "1";
                    addquestion.Answer = model.Question;
                    addquestion.Category = model.Category;
                    addquestion.Type = model.Type;
                  
                    if (_Question.Add(addquestion))
                    {
                        TempData["Success"] = "Question Added Successfully";
                        return RedirectToAction("Index", "Question");
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