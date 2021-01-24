    public class FlightOptionsList
    {
        [JsonProperty("air:FlightOption")]
        public AirFlightoption[] airFlightOption { get; set; }
    }
    public class AirFlightoption
    {
        public string LegRef { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        [JsonProperty("air:Option")]
        public AirOption airOption { get; set; }
    }
    public class AirOption
    {
        public string Key { get; set; }
        public string TravelTime { get; set; }
        [JsonProperty("air:BookingInfo")]
        public AirBookingInfo[] airBookingInfo { get; set; }
        [JsonProperty("air:Connection")]
        public AirConnection airConnection { get; set; }
    }
    public class AirBookingInfo
    {
        public string BookingCode { get; set; }
        public string BookingCount { get; set; }
        public string CabinClass { get; set; }
        public string FareInfoRef { get; set; }
        public string SegmentRef { get; set; }
    }
    public class AirConnection
    {
        public string SegmentIndex { get; set; }
    }
