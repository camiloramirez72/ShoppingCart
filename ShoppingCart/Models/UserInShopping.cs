using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class UserInShopping
    {
        public static List<UserInShopping> usersInShopping = new List<UserInShopping>();
        public int UserId { get; set; }

        public ShoppingBasket shoppingBasket { get; set; }


        public UserInShopping(int userId, ShoppingBasket shoppingBasket)
        {
            UserId = userId;
            this.shoppingBasket = shoppingBasket;
            usersInShopping.Add(this);
        }

    }
}
