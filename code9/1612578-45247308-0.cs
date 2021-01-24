    public class Stock
    {
        public string Name { get; set; }
        public IEnumerable<IDictionary<string, string>> DailyClosePrice { get; set; }
    }
    public class DailyClosePice
    {
        public string Date { get; set; }
        public double Price { get; set; }
    }
