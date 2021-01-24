    [JsonConverter(typeof(VehicleConverter))]
    public class Vehicle
    {
        [JsonProperty(PropertyName = "pre")]
        public string Prefix { get; set; }
        public Position Position { get; set; }
    }
