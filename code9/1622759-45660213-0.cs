    public class Rootobject
    {
    	public string State { get; set; }
    	public string District { get; set; }
    	public Fact Fact { get; set; }
    	public string Description { get; set; }
    	public string CaseDate { get; set; }
    	public string FactNumber { get; set; }
    	public string FactType { get; set; }
    }
    
    public class Fact
    {
    	public string Id { get; set; }
    }
