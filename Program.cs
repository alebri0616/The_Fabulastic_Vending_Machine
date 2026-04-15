using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Fantastic Vending Machine";

            User user = new User("You", 50.00m);
            Inventory inventory = new Inventory();
            Bank bank = new Bank();
            VendingMachine machine = new VendingMachine(inventory, bank);

            UI ui = new UI(user, machine);
            ui.Run();
        }
    }
}