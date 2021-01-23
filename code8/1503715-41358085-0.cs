    internal class Program
    {
        public static List<Item> ShoppingCart { get; set; }
        public static void Main()
        {
            ShoppingCart = new List<Item>();
            AddToCart(new Item() { ProductId = 2322, Quantity = 1 });
            AddToCart(new Item() { ProductId = 5423, Quantity = 2 });
            AddToCart(new Item() { ProductId = 1538, Quantity = 1 });
            AddToCart(new Item() { ProductId = 8522, Quantity = 1 });
        }
        
        public static void AddToCart(Item item)
        {
            ShoppingCart.Add(new Item() { ProductId = item.ProductId, Quantity = item.Quantity});
        }
    }
    public class Item
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
