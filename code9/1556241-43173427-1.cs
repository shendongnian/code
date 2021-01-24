    public class LocationChannelEvent : Activity.Channel.Event
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float? Distance { get; set; }
        public float? Altitude { get; set; }
        /// <summary>
        /// Speed in m/s
        /// </summary>
        public float? Speed { get; set; }
    }
    public class Location
    {
        [JsonConverter(typeof(StructuredListConverter<LocationChannelEvent>))]
        public List<LocationChannelEvent> events { get; set; }
    }
    public class RootObject
    {
        public Location location { get; set; }
    }
