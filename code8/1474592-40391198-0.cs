    public class Products
    {
      [XmlElement("Product", Type = typeof(Product))]
      public List<Product> Products { get; set; }
    }
    public class Product
    {
      [XmlElement("Description")]
      public string Description { get; set; }
      ...
    }
