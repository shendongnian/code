    class Container
    {
    	public List<Dictionary<string, List<Cfg>>> Sonos { get; set;}
    }
    
    class Cfg
    {
    	public string Volume { get; set; }
    }
    // ...
    var container = JsonConvert.DeserializeObject<Container>(json);
