using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce2.console.models
{
    public abstract class User
    {
        public Guid Id { get; }
        public string FullName { get; }
        public string Email { get; }

        protected User (Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }
    }
}
