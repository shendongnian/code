    public class Body
    {
        public string mode { get; set; }
        // This property is a raw string in the json document
        [JsonConverter(typeof(RawConverter))]
        public Data raw { get; set; }
    }
    public class RootObject
    {
        public Body body { get; set; }
        public string description { get; set; }
    }
    public class Data
    {
        public string Token { get; set; }
        public string queryName { get; set; }
        public DataTestToSEND dataTestToSEND { get; set; }
    }
    public class DataTestToSEND
    {
        public string[] IDs { get; set; }
        public string Marketplace { get; set; }
        public string Region { get; set; }
        public int PricingMethod { get; set; }
    }
