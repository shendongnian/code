    public class Datum
    {
        public long time { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal open { get; set; }
        public double volumefrom { get; set; }
        public double volumeto { get; set; }
    }
    
    public class ConversionType
    {
        public string type { get; set; }
        public string conversionSymbol { get; set; }
    }
    
    public class RootObject
    {
        public string Response { get; set; }
        public int Type { get; set; }
        public bool Aggregated { get; set; }
        public List<Datum> Data { get; set; }
        public long TimeTo { get; set; }
        public long TimeFrom { get; set; }
        public bool FirstValueInArray { get; set; }
        public ConversionType ConversionType { get; set; }
    }
