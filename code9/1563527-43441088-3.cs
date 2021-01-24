    public class RootObject
    {
        [JsonConverter(typeof(CharListConverter))]
        public List<char> Characters { get; set; }
    }
