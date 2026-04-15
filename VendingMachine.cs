using System;

namespace VendingMachine
{

    class VendingMachine
    {
        private Inventory inventory;
        private Bank bank;

        public VendingMachine(Inventory inventory, Bank bank)
        {
            this.inventory = inventory;
            this.bank = bank;
        }

        public void ShowInventory()
        {
            inventory.Display();
        }

     
        public bool BuyProduct(int productNumber, User user)
        {
            Product product = inventory.GetProduct(productNumber);

            if (product == null)
            {
                Console.WriteLine("\n  Invalid product number. Please try again.");
                return false;
            }

            bool success = bank.ProcessPayment(user, product);

            if (success)
            {
                user.ReceiveProduct(product);
                Console.WriteLine($"\n  Here is your {product.Emoji} {product.Name}! Enjoy!");
                Console.WriteLine($"  Remaining balance: {user.Balance:F2} kr");
            }

            return success;
        }

        public void InsertMoney(User user, decimal amount)
        {
            bank.AddFunds(user, amount);
        }
    }
}