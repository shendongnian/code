    public class Restaurant
    {
    	public ObjectId _id { get; set; }
    	public address address { get; set; }
    	public string borough { get; set; }
    	public string cuisine { get; set; }
    	public grades[] grades {get;set;}
    	public string name { get; set; }
    	public string restaurant_id {get;set;}
    }
    
    public class grades
    {
    	public DateTime date {get;set;}
    	public string grade {get;set;}
    	public int? score {get;set;}
    }
    
    public class address
    {
    	public string building { get; set; }
    	public double[] coord { get; set; }
    	public string street { get; set; }
    	public string zipcode { get; set;}
    }
