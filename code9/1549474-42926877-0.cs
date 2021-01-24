    public interface IDataSource
    {
        event HistoricalDataReceivedEventRaiser OnHistoricalDataReceived;
        List<DailyPrice> RequestHistoricalData(string symbol, List<PriceField> fields, DateTime? firstDate=null, DateTime? lastDate=null);
    }
