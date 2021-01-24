    public class Product
    {
        public Product(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
