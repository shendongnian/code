    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    foreach (var offer in obj.Reserved.Values.SelectMany(v => v.Values))
    {
        Console.WriteLine(offer.effectiveDate);
        foreach (var priceDim in offer.priceDimensions.Values)
            Console.WriteLine("\t" + priceDim.description);
    }
    // .....................
    public class RootObject
    {
        public Dictionary<string, Dictionary<string, Offer>> Reserved { get; set; }
    }
    public class Offer
    {
        public string offerTermCode { get; set; }
        public string sku { get; set; }
        public DateTime effectiveDate { get; set; }
        public Dictionary<string, PriceDimension> priceDimensions { get; set; }
        public TermAttributes termAttributes { get; set; }
    }
    public class PriceDimension
    {
        public string rateCode { get; set; }
        public string description { get; set; }
        public string beginRange { get; set; }
        public string endRange { get; set; }
        public string unit { get; set; }
        public Dictionary<string, string> pricePerUnit { get; set; }
        public object[] appliesTo { get; set; }
    }
    public class TermAttributes
    {
        public string LeaseContractLength { get; set; }
        public string OfferingClass { get; set; }
        public string PurchaseOption { get; set; }
    }
