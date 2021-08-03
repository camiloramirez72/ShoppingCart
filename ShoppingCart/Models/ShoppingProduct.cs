using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ShoppingProduct
    {
        public int UserId { get; set; }
        public int ProductCode { get; set; }

        public int Quantity { get; set; }
    }
}
