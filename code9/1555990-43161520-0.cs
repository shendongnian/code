    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Category Category { get; set; }
    }
