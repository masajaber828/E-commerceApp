using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce2.console.models
{
    public class Customer : User 
    {
        public bool IsVip { get; set; }
        public Customer (Guid id, string fullName,string Password, string email, bool isVip = false)
            : base (id, fullName, email)
        {
            IsVip = isVip;
        }
    }
}
