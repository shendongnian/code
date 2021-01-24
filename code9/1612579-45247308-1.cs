    public class Stock
    {
        public string Name { get; set; }
        public IEnumerable<IDictionary<DateTime, float>> DailyClosePrice { get; set; }
    }
