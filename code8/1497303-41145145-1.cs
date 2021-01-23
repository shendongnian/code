    public class Products
    {
        [XmlElement("Product")]
        public ProductNameList Product { get; set; }
    }
    public class ProductNameList
    {
        [XmlElement("productName")]
        public List<string> ProductName { get; set; }
    }
