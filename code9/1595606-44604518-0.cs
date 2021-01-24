    class StockResponse
    {
        public int status { get; set; }
        public int time { get; set; }
        public Dictionary<string,StockData> response { get; set; }
    }
    
    class StockData
    {
        public int price { get; set; }
        public int quantity { get; set; }
    }
