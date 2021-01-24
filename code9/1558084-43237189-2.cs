    public class Root
    {
    	public Dictionary<string, List<CustomClass1>> Data { get; set; }
    }
    
    public class CustomClass1
    {
    	public DateTime Date { get; set; }
    
    	public Dictionary<string, int> Values { get; set; }
    }
