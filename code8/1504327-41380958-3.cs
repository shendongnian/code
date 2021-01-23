    public static class Inventory
    {        
        public static List<Product> Products { get; private set; }
        static Inventory()
        {
             Products = new List<Product>();
        }
    }
