using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Models
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}