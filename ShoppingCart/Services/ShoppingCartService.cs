using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using System;

namespace ShoppingCart.Services
{
    public class ShoppingCartService
    {
        enum Action
        {
            newShoppingCart,
            modimodifyShoppingCart,
            addShoppingCart
        }
        public static ActionResult addInShoppingCart(ShoppingProduct shoppingProduct)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Product product = Product.Instance.Find(p => p.ProductCode.Equals(shoppingProduct.ProductCode));
            if (product == null) {
                return new NotFoundResult();
            }
            else
            {
                UserInShopping userInShopping = UserInShopping.usersInShopping.Find(u => u.UserId.Equals(shoppingProduct.UserId));
                switch (SelectAction(product, userInShopping)){
                    case Action.newShoppingCart:
                        {
                            ProductInShoppingBasket productInShoppingBasket = new ProductInShoppingBasket(product, shoppingProduct.Quantity);
                            ShoppingBasket shoppingBasket = new ShoppingBasket(shoppingProduct.UserId, productInShoppingBasket);
                            userInShopping = new UserInShopping(shoppingProduct.UserId, shoppingBasket);
                            System.Console.WriteLine("[ITEM ADDED IN SHOPPING CART]: ADDED[<{0:dd/MM/yyyy}>], {1}, {2}, {3}, <€{4}> ",
                                DateTime.Now, userInShopping.UserId, shoppingProduct.ProductCode, shoppingProduct.Quantity, product.UnitPrice);
                            return new OkObjectResult(shoppingBasket);
                        }
                    case Action.modimodifyShoppingCart:
                        {
                            userInShopping.shoppingBasket.ProductInShoppingBaskets.Find(p => p.product.Equals(product)).Quantity = shoppingProduct.Quantity;
                            System.Console.WriteLine("[ITEM MODIFIED TO SHOPPING CART]: MODIFIED[<{0:dd/MM/yyyy}>], {1}, {2}, {3}, <€{4}> ", 
                                DateTime.Now, userInShopping.UserId, shoppingProduct.ProductCode, shoppingProduct.Quantity, product.UnitPrice);
                            return new OkObjectResult(userInShopping);
                        }
                    case Action.addShoppingCart:
                        {
                            ProductInShoppingBasket productInShoppingBasket = new ProductInShoppingBasket(product, shoppingProduct.Quantity);
                            userInShopping.shoppingBasket.ProductInShoppingBaskets.Add(productInShoppingBasket);
                            System.Console.WriteLine("[ITEM ADDED IN SHOPPING CART]: ADDED[<{0:dd/MM/yyyy}>], {1}, {2}, {3}, <€{4}> ",
                                DateTime.Now, userInShopping.UserId, shoppingProduct.ProductCode, shoppingProduct.Quantity, product.UnitPrice);
                            return new OkObjectResult(userInShopping);
                        }
                }
            }
            return null;
        }

        public static ActionResult getBill(int userId)
        {
            UserInShopping userInShopping = UserInShopping.usersInShopping.Find(u => u.UserId.Equals(userId));
            if (userInShopping == null)
            {
                return new NotFoundResult();
            }
            String bill = String.Format("- Creation date: {0:dd/MM/yyyy}", userInShopping.shoppingBasket.DateCreated);
            double total = 0;
            foreach (ProductInShoppingBasket p in userInShopping.shoppingBasket.ProductInShoppingBaskets)
            {
                double costByProduct = p.Quantity * p.product.UnitPrice;
                total = total + costByProduct;
                bill = bill + String.Format("{0}- {1} x {2,-15} // {1} x {3} = {4}" 
                    , Environment.NewLine, p.Quantity, p.product.ProductName, p.product.UnitPrice, costByProduct);
            }
            bill = bill + String.Format("{0}- Total: €{1}", Environment.NewLine, total);
            return new OkObjectResult(bill);
        }

        //Return the action to do deppending if the user have shopping basket and if the product isset in the user's shopping basket
        static private Action SelectAction(Product product, UserInShopping userInShopping)
        {
            if (userInShopping == null || userInShopping.shoppingBasket == null)
            {
                return Action.newShoppingCart;
            }
            else
            {
                if (userInShopping.shoppingBasket.ProductInShoppingBaskets.Find(p => p.product.Equals(product)) == null)
                {
                    return Action.addShoppingCart;
                }
                else
                {
                    return Action.modimodifyShoppingCart;
                }
            }
        }
    }
}
