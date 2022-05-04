using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace TaskManagementSystem
{
    public class CustomerSecurity
    {
        public  static bool Login(string username,string password)
        {
            using (TaskManagementEntities entities=new TaskManagementEntities())
            {
                return entities.Customer.Any(user=>user.Name == username && user.Password == password);
            }
        }
    }
}