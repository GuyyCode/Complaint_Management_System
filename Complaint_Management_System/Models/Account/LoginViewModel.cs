using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Complaint_Management_System.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Student Number")]
        public string StudentNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public bool Success { get; set; }
    }
}
