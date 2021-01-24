    public class Product
    {
        public string ProductID { get; set; }
        //product in a product search listing
        public string StoreName { get; set; }
        public string SearchToken { get; set; }
        public Dictionary<string, object> Fields { get; set; }
    }
