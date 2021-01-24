    public class FlightOptionsList
    {
        public List<FlightOption> FlightOption { get; set; }
    }
    public class FlightOption
    {
        public string LegRef { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public Option Option { get; set; }
    }
    public class Option
    {
        public string Key { get; set; }
        public string TravelTime { get; set; }
        [JsonConverter(typeof(SingleValueArrayConverter<BookingInfo>))]
        public List<BookingInfo> BookingInfo { get; set; }
        public Connection Connection { get; set; }
    }
    public class BookingInfo
    {
        public string BookingCode { get; set; }
        public string BookingCount { get; set; }
        public string CabinClass { get; set; }
        public string FareInfoRef { get; set; }
        public string SegmentRef { get; set; }
    }
    public class Connection
    {
        public string SegmentIndex { get; set; }
    }
