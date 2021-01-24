    public class Crypto
    {
        public List<Ticker> Tickers { get; set; }
    }
    public class Ticker
    {
        public string Currency { get; set; }
        public string Target { get; set; }
        public string Price { get; set; }
    }
