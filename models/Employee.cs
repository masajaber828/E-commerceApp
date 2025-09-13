using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce2.console.models
{
    public  class Employee : User 
    {
        public string Role { get; set; }
        public Employee (Guid id, string fullName, string email, string role) : base (id, fullName, email)
        {
            Role = role;
        }
    }
}
