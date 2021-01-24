    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual Category Category { get; set; }
    }
    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryDescription { get; set; }
    }
