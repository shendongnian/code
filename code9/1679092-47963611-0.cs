    public class StreetAddress
    {
        [JsonProperty(Order = 1)]
        public Int32 Number { get; set; }
        [JsonProperty(Order = 2)]
        public String StreetName { get; set; }
        [JsonProperty(Order = 3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public StreetType StreetType { get; set; }
        [JsonProperty(Order = 3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Direction Direction { get; set; }
    }
