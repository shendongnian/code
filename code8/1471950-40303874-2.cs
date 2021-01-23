    public class Product
    {
        private readonly List<string> _categories;
        public Product() : this(new List<string>() { "Miscellanous"})
        {
        }
        
        public Product(List<string> category)
        {
            _categories = category;
        }
    }
