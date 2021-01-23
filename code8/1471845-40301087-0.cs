    public class Country
    {
    	public string code { get; set; }
    }
    
    public class Location
    {
    	public Country country { get; set; }
    	public string name { get; set; }
    }
    
    public class PictureUrls
    {
    	public int _total { get; set; }
    	public List<string> values { get; set; }
    }
    
    public class JsonResult
    {
    	public string firstName { get; set; }
    	public string headline { get; set; }
    	public Location location { get; set; }
    	public PictureUrls pictureUrls { get; set; }
    }
