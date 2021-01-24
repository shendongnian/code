    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
