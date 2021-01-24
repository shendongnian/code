    public sealed class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<Product> Products { get; set; }
        // uncomment this line to reproduce the issue
        // public ICollection<Subtype> Subtypes { get; set; } //<- here 2
    }
