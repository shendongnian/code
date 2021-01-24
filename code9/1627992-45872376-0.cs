    public class DataObject
    {
    	[JsonProperty("odata.metadata")]
    	public string ODataMetadata { get; set; }
    
    	public IEnumerable<Dictionary<string, string>> Value { get; set; }
    }
