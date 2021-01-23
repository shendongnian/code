    class ResourceProperties
    {
	    public string GroupDescription { get; set; }
    }
    class Resource
    {
	    public string Type { get; set; }
    	public ResourceProperties Properties { get; set; }
    }
    class Parameters
    {
	    public Dictionary<string, Resource> Resources { get; set; }
    }
    class Template
    {
	    public Parameters Parameters { get; set; }
    }
