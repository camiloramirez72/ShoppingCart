using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ShoppingBasket
    {
        public int UserId { get; set; }

        public System.DateTime DateCreated { get; set; }

        public List<ProductInShoppingBasket> ProductInShoppingBaskets { get; set; }

        public ShoppingBasket(int userId, ProductInShoppingBasket productInShoppingBasket)
        {
            UserId = userId;
            DateCreated = DateTime.Now;
            List<ProductInShoppingBasket> productInShoppingBaskets = new List<ProductInShoppingBasket>();
            productInShoppingBaskets.Add(productInShoppingBasket);
            ProductInShoppingBaskets = productInShoppingBaskets;
            System.Console.WriteLine("[BASKET CREATED]: Created[<{0:dd/MM/yyyy}>], {1}", DateCreated, UserId);
        }
    }
}
