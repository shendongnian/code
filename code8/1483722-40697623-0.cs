    public class ProductInstance
    {
        public int Id { get; set; }
        public Sale Sale { get; set; }
    }
    
    public class Sale
    {
        public int Id { get; set; }
        public ProductInstance ProductInstance { get; set; }
    }
