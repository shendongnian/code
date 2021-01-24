    public class Carpark {
    	
    	[JsonProperty(PropertyName = "name")]
    	public string Name{ get; set; }
    	
    	[JsonProperty(PropertyName = "id")]
    	public int Id {get; set;}
    	
    	[JsonProperty(PropertyName = "cars")]
    	public IEnumerable<Car> Cars { get; set; }
    }
    
    public class Car {
    	
    	[JsonProperty(PropertyName = "id")]
    	public int Id { get; set; }
    	
    	[JsonProperty(PropertyName = "model")]
    	public string Model { get; set; }
    	
    	[JsonProperty(PropertyName = "engine")]
    	public string Engine { get; set; }
    }
