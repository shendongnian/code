    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    public class YourObject
    {
        public int ID { get; set; }
        public List<Product> Products { get; set; }
        public string Title { get; set; }
    }
