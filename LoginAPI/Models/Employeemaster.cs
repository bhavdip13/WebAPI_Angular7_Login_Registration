//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employeemaster
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string Gender { get; set; }
        public string Skills { get; set; }
        public byte[] Profile { get; set; }
        public Nullable<int> IsApporved { get; set; }
        public Nullable<int> LoginTryCnt { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
