using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class Login
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
   
    public class Registration 
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string Gender { get; set; }
        public string Skills { get; set; }
        public string Profile { get; set; }
        public bool IsApporved { get; set; }
      
    }
}