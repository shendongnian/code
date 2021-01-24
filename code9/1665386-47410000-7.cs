    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class Category
    {
        public string Name { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    
    }
