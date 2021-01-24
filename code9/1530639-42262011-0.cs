    public class Stock
    {
        public string Symbol { get; set; }
        public ObservableCollection<StockInfo> StockInfos { get; } = new ObservableCollection<StockInfo>();
    }    
    public class StockInfo
    {
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public double Range { get; set; }
    }
