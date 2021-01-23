    [JsonConverter(typeof(ObjectToArrayConverter<Player>))]
    public class Player
    {
        [JsonProperty(Order = 1)]
        public int UniqueID { get; set; }
        [JsonProperty(Order = 2)]
        public string PlayerDescription { get; set; }
        // Other fields as required.
    }
