    public class Model 
    {
        public int ID { get; set; }
        [JsonConverter(typeof(CustomDictionaryConverter))]
        public Dictionary<string, string> Dic { get; set; }
    }
