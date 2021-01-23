    public static class Inventory
    {
        public static List<Product> Products { get; set; }   
        static Inventory()
        {
            Products = new List<Product>();
        }
    }
