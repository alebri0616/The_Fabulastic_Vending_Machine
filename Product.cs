namespace VendingMachine
{
    // Represents a single product in the vending machine
    class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string Emoji { get; private set; }

        public Product(string name, decimal price, int quantity, string emoji)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Emoji = emoji;
        }

        public bool IsInStock()
        {
            return Quantity > 0;
        }

        public void ReduceStock()
        {
            Quantity--;
        }
    }
}