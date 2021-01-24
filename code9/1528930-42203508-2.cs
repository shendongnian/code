    public class Test {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JToken> AdditionalProperties { get; set; } = new Dictionary<string, JToken>();
    }
    var test = new Test();
    test.AdditionalProperties["new_pro"] = 123456;
    test.Id = 1;
    test.Name = "Dog";            
    var r = Newtonsoft.Json.JsonConvert.SerializeObject(test);
