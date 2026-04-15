using System;
 
namespace VendingMachine
{
   
    class Bank
    {
        public decimal TotalCollected { get; private set; }
 
        public Bank()
        {
            TotalCollected = 0;
        }
 
        public bool ProcessPayment(User user, Product product)
        {
            if (!product.IsInStock())
            {
                Console.WriteLine($"\n  Sorry, {product.Name} is sold out!");
                return false;
            }
 
            if (!user.CanAfford(product.Price))
            {
                Console.WriteLine($"\n  Not enough money! You need {product.Price:F2} kr but only have {user.Balance:F2} kr.");
                return false;
            }
 
            user.Pay(product.Price);
            product.ReduceStock();
            TotalCollected += product.Price;
            return true;
        }
 
        
        public void AddFunds(User user, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\n  Please enter a positive amount.");
                return;
            }
 
            
            decimal[] validAmounts = { 1, 2, 5, 10, 20, 50, 100, 200, 500 };
            bool valid = false;
            foreach (decimal v in validAmounts)
            {
                if (amount == v) { valid = true; break; }
            }
 
            if (!valid)
            {
                Console.WriteLine("\n  Invalid amount. Use: 1, 2, 5, 10, 20, 50, 100, 200 or 500 kr.");
                return;
            }
 
            user.Balance += amount;
            Console.WriteLine($"\n  Added {amount:F2} kr. New balance: {user.Balance:F2} kr.");
        }
    }
}