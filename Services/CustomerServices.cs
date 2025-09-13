using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce2.console.models;

namespace Ecommerce2.console.Services
{
    public  class CustomerServices
    {
        private readonly List<Customer> _customers = new();
        public Customer Register (string fullName, string email, bool isVip = false)
        {
            string password = "";
            var customer = new Customer(Guid.NewGuid(), fullName,password, email, isVip);
            _customers.Add(customer);
            return customer;
        }

        public IEnumerable<Customer> GetAll() => _customers;
    }
}





        
    

