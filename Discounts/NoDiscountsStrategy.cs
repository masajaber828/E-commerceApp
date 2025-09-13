using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce2.console.Discounts
{
    public class NoDiscountsStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalAmount) => 0m;
    }
}
