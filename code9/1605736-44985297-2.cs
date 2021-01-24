    public class Products 
    {
       public string product_id { get; set; }
       public string title { get; set; }
       public string price { get; set; }
    }
    
    public class Config
    {
      public string token { get; set; }
      public string site { get; set; }
      public string mode { get; set; }
    }
    
    public class ProductConfig 
    {
       public List<Products> Products { get; set; }
       public Config Config { get; set; }
    }
