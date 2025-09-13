using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce2.console.Discounts
{
    public interface IDiscountStrategy
    {
        
            decimal ApplyDiscount(decimal subtotal);
        }
    }

