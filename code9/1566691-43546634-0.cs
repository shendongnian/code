    public class MyObject
    {	
        public string Name { get; set; }
    	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<MyObject> Children { get; set; }
    	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Size { get; set; }
    }
