using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce2.console.models;

namespace Ecommerce2.console.Services
{
    public class EmployeeServices
    {
        private readonly List<Employee> _employees = new();
        public Employee AddEmployee(string fullName, string email, string role)
        {
            var employee = new Employee(Guid.NewGuid(), fullName, email, role);
            _employees.Add(employee);
            return employee;
        }
        public IEnumerable<Employee> GetAll() => _employees;
    }
}
