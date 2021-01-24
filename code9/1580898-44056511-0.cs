    public class Severity
    {
	
        [JsonProperty("entities")]
        public List<Entity> Entities { get; set; }
	
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    public class Entity
    {
	    [JsonProperty("id")]
        public string Id;
	
        [JsonProperty("Name")]
        public string Name;
    }
    
    public class Paging
    {
        [JsonProperty("from")]
        public int From { get; set; }
    
        [JsonProperty("limit")]
        public int Limit { get; set; } 
    
        [JsonProperty("hasMore")]
        public bool HasMore { get; set; } 
    }
