       public class Category
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
