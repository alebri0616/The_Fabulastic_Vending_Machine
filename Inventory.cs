using System;
using System.Collections.Generic;

namespace VendingMachine
{
    
    class Inventory
    {
        public List<Product> Products { get; private set; }

        public Inventory()
        {
            
            Products = new List<Product>
            {
                new Product("Cola",         12.00m, 5, "🥤"),
                new Product("Water",         8.00m, 5, "💧"),
                new Product("Orange Juice", 15.00m, 3, "🍊"),
                new Product("Chips",        10.00m, 4, "🥔"),
                new Product("Chocolate",    14.00m, 4, "🍫"),
                new Product("Candy",         6.00m, 6, "🍬"),
                new Product("Sandwich",     25.00m, 2, "🥪"),
                new Product("Coffee",       18.00m, 3, "☕"),
            };
        }

        
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("  +----+----------------+----------+-------------+");
            Console.WriteLine("  |  # | Product        |  Price   |    Stock    |");
            Console.WriteLine("  +----+----------------+----------+-------------+");

            for (int i = 0; i < Products.Count; i++)
            {
                Product p = Products[i];
                string stock = p.IsInStock() ? $"{p.Quantity} left" : "SOLD OUT";
                string price = $"{p.Price:F2} kr";
                Console.WriteLine($"  | {i + 1,2} | {p.Emoji} {p.Name,-12} | {price,8} | {stock,11} |");
            }

            Console.WriteLine("  +----+----------------+----------+-------------+");
        }

        
        public Product GetProduct(int number)
        {
            int index = number - 1;
            if (index < 0 || index >= Products.Count)
                return null;
            return Products[index];
        }
    }
}