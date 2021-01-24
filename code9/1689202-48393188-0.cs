    [XmlRoot("ProductType", Namespace = "http://api.namecheap.com/xml.response")]
    public class ProductType
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlElement("ProductCategory")]
        public ProductCategory[] ProductCategories;
    }
    public class ProductCategory
    {
        [XmlElement("Product")]
        public Product[] Products;
    }
    public class Product
    {
        [XmlElement("Price")]
        public ProductPrice[] Prices;
    }
    public class ProductPrice
    {
        [XmlAttribute]
        public int Duration;
        [XmlAttribute]
        public string DurationType;
        [XmlAttribute]
        public decimal Price;
        [XmlAttribute]
        public decimal RegularPrice;
        [XmlAttribute]
        public decimal YourPrice;
        [XmlAttribute]
        public string CouponPrice;
        [XmlAttribute]
        public string Currency;
    }
