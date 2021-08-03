using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ProductInShoppingBasket
    {
        public Product product { get; set; }

        public int Quantity { get; set; }

        public ProductInShoppingBasket(Product product, int quantity)
        {
            this.product = product;
            Quantity = quantity;
        }

    }
}
