using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace TaskManagementSystem.Controllers
{
    public class AccountController : ApiController
    {
        //api/Account
        public IEnumerable<Customer> Get()
        {
            using (TaskManagementEntities entities = new TaskManagementEntities())
            {
                return entities.Customer.ToList();
            }
        }
        public void post([FromBody] Customer customer)
        {
            using (TaskManagementEntities entities = new TaskManagementEntities())
            {
                entities.Customer.Add(customer);
                entities.SaveChanges();
            }

        }
    }
}
