using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce2.console.models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
         
        public Order (Guid id, Customer customer, List<Product> products, decimal subtotal, decimal discount, decimal total)
        {
            Id = id;
            Customer = customer;
            Products = products;
            Subtotal = subtotal;
            Discount = discount;
            Total = total;
        }


    }
}
