    public class Pre
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }
    public class Regular
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }
    public class Post
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }
    public class CurrentTradingPeriod
    {
        public Pre pre { get; set; }
        public Regular regular { get; set; }
        public Post post { get; set; }
    }
    public class Meta
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public string exchangeName { get; set; }
        public string instrumentType { get; set; }
        public int firstTradeDate { get; set; }
        public int gmtoffset { get; set; }
        public string timezone { get; set; }
        public string exchangeTimezoneName { get; set; }
        public CurrentTradingPeriod currentTradingPeriod { get; set; }
        public string dataGranularity { get; set; }
        public List<string> validRanges { get; set; }
    }
    public class Quote
    {
        public List<object> volume { get; set; }
        public List<double?> low { get; set; }
        public List<double?> high { get; set; }
        public List<double?> close { get; set; }
        public List<double?> open { get; set; }
    }
    public class Unadjclose
    {
        public List<double?> unadjclose { get; set; }
    }
    public class Unadjquote
    {
        public List<double?> unadjopen { get; set; }
        public List<double?> unadjclose { get; set; }
        public List<double?> unadjhigh { get; set; }
        public List<double?> unadjlow { get; set; }
    }
    public class Indicators
    {
        public List<Quote> quote { get; set; }
        public List<Unadjclose> unadjclose { get; set; }
        public List<Unadjquote> unadjquote { get; set; }
    }
    public class Result
    {
        public Meta meta { get; set; }
        public List<int> timestamp { get; set; }
        public Indicators indicators { get; set; }
    }
    public class Chart
    {
        public List<Result> result { get; set; }
        public object error { get; set; }
    }
    public class RootObject
    {
        public Chart chart { get; set; }
    }
