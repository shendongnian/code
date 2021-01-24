        public class Extra
        {
            public string code { get; set; }
            public object value { get; set; }
        }
        public class Product
        {
            public string sku { get; set; }
            public List<Extra> extras { get; set; }
        }
        public class RootObject
        {
            public Product product { get; set; }
        }
