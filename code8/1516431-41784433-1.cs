    public class RootObject
    {
        [JsonConverter(typeof(StrictIntConverter))]
        public int id { get; set; }
        public string name { get; set; }
    }
