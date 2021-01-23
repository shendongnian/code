    void Main()
    {
    	var json =  @"{""rain"":{""3h"":0.46}}";
    	var result = JsonConvert.DeserializeObject<MyThing>(json);
    }
    
    public class MyThing
    {
    	public Dictionary<string, double> rain { get; set; }
    }
