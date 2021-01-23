    public class Product 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
    public class Part
    {
        public int PartId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set;}
    }
