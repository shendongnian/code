    public class Light
    {
    
    	public Light()
    	{
    
    	}
    
    	[JsonProperty("name")]
    	public string LightName { get; set;}
    	
    	[JsonProperty("state")]
    	public State State { get; set; }
    }
    
    public class State 
    {
    	public State() 
    	{
    	}
    	
    	[JsonProperty("on")]
    	public bool IsOn { get; set; }
    
    	[JsonProperty("sat")]
    	public int Saturation { get; set; }
    
    	[JsonProperty("bri")]
    	public int Brightness {get;set;} 
    
    	[JsonProperty("hue")]
    	public int Hue { get; set; }
    }
