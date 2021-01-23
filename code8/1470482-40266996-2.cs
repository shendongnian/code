    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Product[] Products { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
 
