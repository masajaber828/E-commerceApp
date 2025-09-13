using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce2.console.Discounts
{
    public class VipDiscountsStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalAmount) => totalAmount * 0.2m; // خصم 20%
    }
}
