    public class Rootobject
    {
  	    public object[] unique_image_url_prefixes { get; set; }
   	     public Products_And_Categories products_and_categories { get; set; }
    }
    
    public class Products_And_Categories
    {
    	public TopsSweaters[] TopsSweaters { get; set; }
    	public Shirts[] Shirts { get; set; }
    }
    public class TopsSweaters
    {
    	public string name { get; set; }
    	public int id { get; set; }
    }
    public class Shirts
    {
    	public string name { get; set; }
    	public int id { get; set; }
    }
