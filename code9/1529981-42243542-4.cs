        public class Product
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class ViewModelProducts {
        public virtual List<Product> Products { get; set; }
    }
