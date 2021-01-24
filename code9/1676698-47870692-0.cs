    private static readonly string Json = "[\r\n  {\r\n    \"key1\": \"value\",\r\n    \"key2\": \"value\",\r\n    \"key3\": \"TYPE_ONE\",\r\n    \"extraData\": {\r\n      \"key4\": \"value\",\r\n      \"key5\": \"value\",\r\n      \"key6\": {\r\n        \"key7\": {\r\n          \"key8\": \"value\",\r\n          \"key9\": \"value\",\r\n          \"key10\": \"value\"\r\n        }\r\n      }\r\n    }\r\n  },\r\n  {\r\n    \"key1\": \"value\",\r\n    \"key2\": \"value\",\r\n    \"key3\": \"TYPE_TWO\",\r\n    \"extraData\": {\r\n      \"key4\": \"value\",\r\n      \"key5\": \"value\",\r\n      \"key6\": {\r\n        \"key7\": [\r\n          {\r\n            \"key8\": \"value\",\r\n            \"key9\": \"value\",\r\n            \"key10\": \"value\"\r\n          },\r\n          {\r\n            \"key8\": \"value1\",\r\n            \"key9\": \"value1\",\r\n            \"key10\": \"value1\"\r\n          },\r\n          {\r\n            \"key8\": \"value2\",\r\n            \"key9\": \"value2\",\r\n            \"key10\": \"value2\"\r\n          }\r\n        ]\r\n      }\r\n    }\r\n  }\r\n]";
    
    private static void Deserialize()
    {
        var switchers = JsonConvert.DeserializeObject<JObject[]>(Json);
        var deserializedType1List = new List<TargetClass<Key6Type1>>();
        var deserializedType2List = new List<TargetClass<Key6Type2>>();
        foreach (var switcher in switchers)
        {
            if (switcher["key3"].Value<string>() == "TYPE_ONE")
            {
                deserializedType1List.Add(JsonConvert.DeserializeObject<TargetClass<Key6Type1>>(JsonConvert.SerializeObject(switcher)));
            }
            else
            {
                deserializedType2List.Add(JsonConvert.DeserializeObject<TargetClass<Key6Type2>>(JsonConvert.SerializeObject(switcher)));
            }
        }
 
        //Do something with the objects...
    }
    
    private class TargetClass<TKey6Type>
    {
        public string key1 { get; set; }
    
        public string key2 { get; set; }
    
        public string key3 { get; set; }
    
        public ExtraData<TKey6Type> extraData { get; set; }
    }
    
    private class ExtraData<TKey6Type>
    {
        public string key4 { get; set; }
    
        public string key5 { get; set; }
    
        public TKey6Type key6 { get; set; }
    }
    
    private class Key6Type2
    {
        public Key7[] key7 { get; set; }
    }
    
    private class Key6Type1
    {
        public Key7 key7 { get; set; }
    }
    
    private class Key7
    {
        public string key8 { get; set; }
        public string key9 { get; set; }
        public string key10 { get; set; }
    }
