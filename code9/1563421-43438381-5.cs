    public class Product
    {
    	[JsonProperty("name")]
    	public string name { get; set; }
    	
    	[JsonProperty("id")]
    	public int id { get; set; }
    }
    
    // Choose either one of the following (they function the same):    
    public class ProductsContainer1
    {
    	[JsonProperty("TopsSweaters")]
    	public List<Product> ProductsList1 { get; set;}
    	
    	[JsonProperty("Shirts")]
    	public List<Product> ProductsList2 { get; set;}
    }
    
    public class ProductsContainer2
    {
        public List<Product> TopsSweaters { get; set; }
    	public List<Product> Shirts { get; set; }
    }
    
    // Choose either one of the following (they function the same): 
    public class Things1
    {
    	[JsonProperty("unique_image_url_prefixes")]
        public object[] Prefixes { get; set;}
        
        [JsonProperty("products_and_categories")]
    	public ProductsContainer1 Products { get; set;}
    }
    public class Things2
    {
    	public object[] unique_image_url_prefixes { get; set;}
    	public ProductsContainer2 products_and_categories { get; set;}
    }
