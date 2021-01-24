    public class Report 
    {
    	[JsonProperty("pK_LibraryDocument")]
        public int id { get; set; }
    	
        public string fileName { get; set; }
        public List<string> AvailableForModules { get; set; }
    }
