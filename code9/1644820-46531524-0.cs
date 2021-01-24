    class ObjectJson
    {
    	public string Value1 { get; set; }
    	public string Value2 { get; set; }
    	public string Value3 { get; set; }
    	public string Value4 { get; set; }
    }
    var data = JsonConvert.DeserializeObject<Dictionary<string,ObjectJson>>( json );
