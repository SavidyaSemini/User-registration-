using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }

        

        public string Password { get; set; }
        public string Remark { get; set; }

    }
}