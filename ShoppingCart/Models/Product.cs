
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Product
    {
        public string ProductName { get; set; }

        public int ProductCode { get; set; }

        public string Description { get; set; }

        public double UnitPrice { get; set; }

        public Category Category { get; set; }

        private static readonly Category[] categories = new[]
        {
            new Category("Books", ""),
            new Category("DVDs", "")
        };

        private static readonly List<Product> products = new List<Product>()
        {
            new Product("Lord of the Rings", "", 10.00, categories[0], 10001),
            new Product("The Hobbit", "", 5.00, categories[0], 10002),
            new Product("Game of Thrones", "", 9.00, categories[1], 20001),
            new Product("Breaking Bad", "", 7.00, categories[1], 20010),
        };


        private Product(string productName, string description, double unitPrice, Category category, int productCode)
        {
            ProductName = productName;
            Description = description;
            UnitPrice = unitPrice;
            Category = category;
            ProductCode = productCode;
        }

        public static List<Product> Instance
        {
            get
            {
                return products;
            }
        }

    }
}
