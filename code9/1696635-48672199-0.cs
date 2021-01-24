    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<FrontPageProduct> InFrontPages { get; set; }
        public List<ProductInCategory> InCategories { get; set; }
    }
