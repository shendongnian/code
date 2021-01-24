    public class Result
    {
        public string MarketName { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
        public double Last { get; set; }
        public double BaseVolume { get; set; }
        public string TimeStamp { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public int OpenBuyOrders { get; set; }
        public int OpenSellOrders { get; set; }
        public double PrevDay { get; set; }
        public string Created { get; set; }
        public object DisplayMarketName { get; set; }
    }
    
    public class MyClass
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Result> result { get; set; }
    }
