using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce2.console.Discounts;
using Ecommerce2.console.models;

namespace Ecommerce2.console.Services
{
    public class OrderServices
    {
        private readonly List<Order> _orders = new();
        public Order CreateOrder(Customer customer, List<Product> products)
        {
            if (products == null || products.Count == 0)
                throw new ArgumentException("Order must have at least one product.");

            decimal subtotal = 0m;
            foreach (var p in products) subtotal += p.Price;

            IDiscountStrategy discountStrategy = customer.IsVip
            ? new VipDiscountsStrategy()
            : new NoDiscountsStrategy();

            decimal discount = discountStrategy.ApplyDiscount(subtotal);
            decimal total = subtotal - discount;

            var order = new Order(Guid.NewGuid(), customer, products, subtotal, discount, total);
            _orders.Add(order);
            return order;


        }
        public IEnumerable<Order> GetOrdersByCustomer(Customer customer) =>
            _orders.FindAll(o => o.Customer.Id == customer.Id);
    }
}
