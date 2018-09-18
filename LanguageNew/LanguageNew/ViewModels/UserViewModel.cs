using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LanguageNew.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="{0} cannot be blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "{0} cannot be blank")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}