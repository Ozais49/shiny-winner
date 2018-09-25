using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LanguageNew.Models;

namespace LanguageNew.ViewModels
{
    public class QuestionViewModel:Questions
    {
        public HttpPostedFileBase Photo { get; set; }
    }
}