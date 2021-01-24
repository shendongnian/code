    public class OuterObject
    {
        public Terms terms { get; set; }
    }
    public class Terms
    {
        public Dictionary<string, OnDemandItem> OnDemand { get; set; }
    }
    public class OnDemandItem
    {
        public Dictionary<string, PriceDimensionsItem> priceDimensions { get; set; }
    }
    public class PriceDimensionsItem
    {
        public string unit { get; set; }
        public string endRange { get; set; }
        public string description { get; set; }
        public object[] appliesTo { get; set; }
        public string rateCode { get; set; }
        public string beginRange { get; set; }
        public PricePerUnit pricePerUnit { get; set; }
    }
    public class PricePerUnit
    {
        public string USD { get; set; }
    }
