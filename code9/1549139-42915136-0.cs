    public class TrackModel 
    {
    	[JsonProperty(PropertyName="headers")] 
    	public Headers headers {get;set;}
    	
    	
    	[JsonProperty(PropertyName="results")] 
    	public List<Results> results {get;set;}
    }
    
    
    public class Headers {
    	public string status {get;set;}
    	public string code {get;set;}
    	public string error_message {get;set;}
    //Rest of the properties
    }
    
    public class Results {
    	public int id {get;set;}
    	public string name {get;set;}
    // Rest of the properties
    }
