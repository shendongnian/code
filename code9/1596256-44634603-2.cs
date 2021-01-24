    public class Category
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Category WithProduct(int id, string name)
        {
            Products.Add(new Product(id, name, Id));
            return this;
        }
    }
