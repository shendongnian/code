    public class RootObject
    {
        public string atcocode { get; set; }
        public string smscode { get; set; }
        public string request_time { get; set; }
        public IDictionary<int, IEnumerable<BusDepartures>> departures { get; set; }
    }
