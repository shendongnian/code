    public class Result
    {
        public string Coin { get; set; }
        public double LP { get; set; }
        public double PBV { get; set; }
        public bool MACD1M { get; set; }
        public bool MACD30M { get; set; }
        public bool MACD1H { get; set; }
        public bool MACD1D { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> results { get; set; }
    }
