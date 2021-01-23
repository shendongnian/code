    public class Model
    {
        [JsonConverter(typeof(CustomHashSetConverter))]
        public HashSet<string> Standards { get; set; }
    }
