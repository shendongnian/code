    public class Bloomberg: IDataSource
    {
        public event EventHandler<HistoricalDataReceivedEventArgs> OnHistoricalDataReceived;
    
        public List<DailyPrice> RequestHistoricalData(string symbol, List<PriceField> fields, DateTime? firstDate=null, DateTime? lastDate=null)
        {
            var data = new List<DailyPrice>(); 
    
            // ... get the data
    
            var args = new HistoricalDataReceivedEventArgs(dataSource: this, symbol: symbol, data: data);
            if (OnHistoricalDataReceived!=null)
            {
                OnHistoricalDataReceived(this, args); // use "this" as sender
            }
        }
    }
    
    public class Reuters: IDataSource
    {
        public event EventHandler<HistoricalDataReceivedEventArgs> OnHistoricalDataReceived;
    
        public List<DailyPrice> RequestHistoricalData(string symbol, List<PriceField> fields, DateTime? firstDate=null, DateTime? lastDate=null)
        {
            var data = new List<DailyPrice>(); 
    
            // ... get the data
    
            var args = new HistoricalDataReceivedEventArgs(dataSource: this, symbol: symbol, data: data);
            if (OnHistoricalDataReceived!=null)
            {
                OnHistoricalDataReceived(this, args); // use this as sender
            }
        }
    }
