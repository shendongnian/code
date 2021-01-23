    class JsonModelContainer
    {
    	public Dictionary<string, JsonModelA> Data { get; set; }
    }
    
    class JsonModelA
    {
    	public JsonModel ModelA { get; set; }
    }
    
    class JsonModel
    {
    	public string Id { get; set; }
    }
