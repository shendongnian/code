    var data = "[{\"name\": \"somename\", \"data\": [[72, 1504601220], [null, 1504601280], [125, 1504605840]]}]";
    var obj = JsonConvert.DeserializeObject<List<TestObject>>(data);
    
    public class TestObject
    {
        [JsonProperty(PropertyName = "name")]
        public string TargetName { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<int?[]> DataPoints { get; set; }
    }
