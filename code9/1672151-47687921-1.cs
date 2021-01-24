    public class PriceList
    {
        public string Price { get; set; }
        public decimal ParsedPrice => decimal.Parse(Price);
    }
