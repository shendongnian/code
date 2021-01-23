    public class Site
    {
        public string id { get; set; }
        public string Sitename { get; set; }
        public string website { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public string Year { get; set; }
    }
    public class Example
    {
        public string retailer { get; set; }
        public List<Site> sites { get; set; }
        public List<Product> Products { get; set; }
    }
	
