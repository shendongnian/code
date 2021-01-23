    public class Products
    {
      [XmlElement("Product", Type = typeof(Product))]
      public List<Product> Products { get; set; }
    }
    public class Product
    {
      [XmlAttribute("Name")]
      public string Name { get; set; }
      [XmlElement("Description")]
      public string Description { get; set; }
      ...
    }
