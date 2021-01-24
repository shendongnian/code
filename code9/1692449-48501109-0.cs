    public class DeserializeModel
    {
         [JsonProperty("name")]
         public string Name { get; set; }
    
         [JsonProperty("greetings")]
         public string Greetings { get; set; }
    }
    					
    public class SerializeModel
    {
    	public SerializeModel(string name, string greets)
    	{
    	    this.WhatsMyName = name;
    		this.Greets = greets;
    	}
    	
         public string WhatsMyName { get; set; }
    
         public string Greets { get; set; }
    }
    					
    public class Program
    {
    	public static string json = @"{name:'John', greetings:'hello'}";
    	
    	public static void Main()
    	{
    		var deserialized = JsonConvert.DeserializeObject<DeserializeModel>(json);
    		
    		Console.WriteLine(JsonConvert.SerializeObject(deserialized));
    		
    		var mappedData = MapToSerializeModel(deserialized);
    		
    		Console.WriteLine(JsonConvert.SerializeObject(mappedData));
    		
    	}
    	
    	public static SerializeModel MapToSerializeModel(DeserializeModel d)
    	{
    		return new SerializeModel(d.Name, d.Greetings);
    	}
    }
