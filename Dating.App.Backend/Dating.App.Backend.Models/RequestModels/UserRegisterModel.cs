using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dating.App.Backend.Models.RequestModels
{
    public class UserRegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8,MinimumLength = 4, ErrorMessage = "You Must Specify password between 4 to 8 characters")]
        public string Password { get; set; }
    }
}
