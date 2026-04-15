using System;
using System.Collections.Generic;

namespace VendingMachine
{
   
    class User
    {
        public string Name { get; private set; }
        public decimal Balance { get; set; }
        public List<Product> PurchasedItems { get; private set; }

        public User(string name, decimal startingBalance)
        {
            Name = name;
            Balance = startingBalance;
            PurchasedItems = new List<Product>();
        }

   
        public bool CanAfford(decimal price)
        {
            return Balance >= price;
        }

       
        public void Pay(decimal amount)
        {
            Balance -= amount;
        }

     
        public void ReceiveProduct(Product product)
        {
            PurchasedItems.Add(product);
        }

        
        public void ShowPurchasedItems()
        {
            if (PurchasedItems.Count == 0)
            {
                Console.WriteLine("  You haven't bought anything yet.");
                return;
            }

            Console.WriteLine($"  Items you have bought ({PurchasedItems.Count} total):");
            foreach (var item in PurchasedItems)
            {
                Console.WriteLine($"    {item.Emoji} {item.Name}");
            }
        }
    }
}