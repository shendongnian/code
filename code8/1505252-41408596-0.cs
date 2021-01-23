    public class ShoppingbasketItem
    {
        public double price { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public int total { get; set; }
    }
    public class Shoppingbasket
    {
        public List<ShoppingbasketItem> shoppingbasket { get; set; }
    }
