    public class YourTwoField
    {
        [JsonProperty("field1")]
        public string FieldOne { get; set; }
        [JsonProperty("field2")]
        public string FieldTwo { get; set; }
    }
    var myfields = Newtonsoft.Json.JsonConvert.DeserializeObject<YourTwoField>(yourJsonString);
    // use values
    myfields.FieldOne
  
    
