    public class Class1
    {
    	public string title { get; set; }
    	public string pubDate { get; set; }
    	public string link { get; set; }
    	public string guid { get; set; }
    	public string author { get; set; }
    	public string thumbnail { get; set; }
    	public string description { get; set; }
    	public string content { get; set; }
    	public Enclosure enclosure { get; set; }
    	public object[] categories { get; set; }
    }
    
    public class Enclosure
    {
    	public string link { get; set; }
    }
