    public class Product
    {
      public Product()  
      {
       this.attributes = new List<Attributes>();
      }
      public string sku { get; set; }
      public string ean { get; set; }
      public string price { get; set; }
      public string description { get; set; }
      public string long_description { get; set; }
      public string img_url { get; set; }
      public Size size { get; set; }
      public Style style { get; set; }
      public Brand brand { get; set; }
      public Color color { get; set; }
      public Category category { get; set; }
      public List<Attributes> attributes { get; set; }
    }
