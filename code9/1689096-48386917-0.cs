    void Main()
    {
    	var json = File.ReadAllText(@"c:\temp\json.txt"); // your json
    	var output = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Target>>(json);
    }
    
    public class Target
    {
    	[Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }
    	[Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
    	[Newtonsoft.Json.JsonProperty("exchangeable")]
        public bool Exchangeable { get; set; }
    	[Newtonsoft.Json.JsonProperty("members")]
        public bool Members { get; set; }
    	[Newtonsoft.Json.JsonProperty("placeholder_id")]
        public int PlaceholderId { get; set; }
    	[Newtonsoft.Json.JsonProperty("noted_id")]
        public int? NotedId { get; set; }
    }
