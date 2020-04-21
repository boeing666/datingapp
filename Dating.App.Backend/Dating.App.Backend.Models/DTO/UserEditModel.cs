using System;
using System.Collections.Generic;
using System.Text;

namespace Dating.App.Backend.Models.DTO
{
    public class UserEditModel
    {
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
