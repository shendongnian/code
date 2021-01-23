    public class Rootobject
    {
    	public Query query { get; set; }
    }
    
    public class Query
    {
    	public Search[] search { get; set; }
    }
    
    public class Search
    {
    	public int ns { get; set; }
    	public string title { get; set; }
    	public string snippet { get; set; }
    }
