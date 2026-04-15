using System;

namespace VendingMachine
{
    // UI handles all menus and reading input from the user
    class UI
    {
        private User user;
        private VendingMachine machine;

        public UI(User user, VendingMachine machine)
        {
            this.user = user;
            this.machine = machine;
        }

        // Main loop — runs until the user chooses to quit
        public void Run()
        {
            ShowWelcome();

            bool running = true;

            while (running)
            {
                ShowMainMenu();
                string input = Console.ReadLine();

                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        machine.ShowInventory();
                        break;
                    case "2":
                        HandleBuyProduct();
                        break;
                    case "3":
                        HandleInsertMoney();
                        break;
                    case "4":
                        Console.WriteLine($"  Your balance: {user.Balance:F2} kr");
                        break;
                    case "5":
                        user.ShowPurchasedItems();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("  Thanks for using the Vending Machine. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("  Unknown option. Please enter a number 1-6.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\n  Press ENTER to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private void ShowWelcome()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("   THE FANTASTIC VENDING MACHINE");
            Console.WriteLine("==========================================");
            Console.WriteLine($"  Welcome, {user.Name}! Starting balance: {user.Balance:F2} kr");
            Console.WriteLine("\n  Press ENTER to start...");
            Console.ReadLine();
            Console.Clear();
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("  MENU");
            Console.WriteLine("==========================================");
            Console.WriteLine("  1. See available products");
            Console.WriteLine("  2. Buy a product");
            Console.WriteLine("  3. Insert money");
            Console.WriteLine("  4. Check my balance");
            Console.WriteLine("  5. See my purchased items");
            Console.WriteLine("  6. Exit");
            Console.WriteLine("==========================================");
            Console.Write("\n  Your choice: ");
        }

        private void HandleBuyProduct()
        {
            machine.ShowInventory();
            Console.WriteLine($"\n  Your balance: {user.Balance:F2} kr");
            Console.Write("  Enter product number (or 0 to cancel): ");

            string input = Console.ReadLine();
            if (input == "0") return;

            if (int.TryParse(input, out int number))
            {
                machine.BuyProduct(number, user);
            }
            else
            {
                Console.WriteLine("\n  Please enter a valid number.");
            }
        }

        private void HandleInsertMoney()
        {
            Console.WriteLine("  Valid amounts: 1, 2, 5, 10, 20, 50, 100, 200, 500 kr");
            Console.Write("  Amount to insert: ");

            string input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal amount))
            {
                machine.InsertMoney(user, amount);
            }
            else
            {
                Console.WriteLine("\n  Please enter a valid number.");
            }
        }
    }
}