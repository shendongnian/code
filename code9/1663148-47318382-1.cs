    public class Field
    {
        public string FIELD_NAME { get; set; }
        public string VALUE { get; set; }
        public int FIELD_ID { get; set; }
        [JsonConverter(typeof(TolerantCollectionConverter))]
        public List<Option> OPTIONS { get; set; }
    }
