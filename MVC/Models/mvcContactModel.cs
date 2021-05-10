using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcContactModel
    {
       
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public Nullable<decimal> PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}