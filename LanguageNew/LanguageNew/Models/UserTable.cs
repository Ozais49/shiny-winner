using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LanguageNew.Models
{
    public class UserTable
    {
        public int Id { get; set; }

        [Display(Name="Full Name")]
        public string Name { get; set; }
        public string Email { get; set; }


        public string Address { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string UserRole { get; set; }

        public string UserGroup { get; set; }

        public int? LoginCount { get; set; }

        public int? RetryLeft { get; set; }

        public DateTime? LastLogin { get; set; }

        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public string ApprovedBy { get; set; }

    }

}