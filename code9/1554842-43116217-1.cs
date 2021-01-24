    public void Test()
    {
        string a = "<content>";
        string b = "<content>";
    
        var obj = new RootObject();
        obj.Fields = new Fields();
    
        obj.Fields.Summary = a;
        obj.Fields.Description = b;
    
        var jsonOutput = Newtonsoft.Json.JsonSerializer.Serialize(obj, typeof(RootObject));
    }
    
    public class Fields
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }
    
        [JsonProperty("description")]
        public string Description { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }
