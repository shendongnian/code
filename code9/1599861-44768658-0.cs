     public class Product
    {
        public string Name {get; set;}
        public string Category {get; set;}
        public int ID {get; set;}
        public static List<Product> ProductList =
            new List<Product>();
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Product> GenerateReport()
        {
            return ProductList;
        }
        
    }
