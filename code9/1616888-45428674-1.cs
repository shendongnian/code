    [JsonConverter(typeof(DPInfoConverter))]
    public class DPInfo
    {
        public string key { get; set; }   // remove this line if you don't need the key
        public decimal[][] points { get; set; }
        public long last { get; set; }
    }
