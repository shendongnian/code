    public class OuterObject
    {
        public Dictionary<string, Products> products { get; set; }
        public Terms terms { get; set; }
    }
    
    public class Products
    {
        public string sku { get; set; }
        public string productFamily { get; set; }
        public Attributes attributes { get; set; }
    }
    
    public class Attributes
    {
        public string servicecode { get; set; }
        public string location { get; set; }
        public string locationType { get; set; }
        public string instanceType { get; set; }
        public string currentGeneration { get; set; }
        public string vcpu { get; set; }
        public string memory { get; set; }
        public string operatingSystem { get; set; }
        public string licenseModel { get; set; }
        public string preInstalledSw { get; set; }
        public string tenancy { get; set; }
    }
    
    public class Terms
    {
        public Dictionary<string, Dictionary<string, OnDemandItem>> OnDemand { get; set; }
        public Dictionary<string, Dictionary<string, OnDemandItem>> Reserved { get; set; }
    }
    
    
    public class OnDemandItem
    {
        public string offerTermCode { get; set; }
        public string sku { get; set; }
        public Dictionary<string, PriceDimensionsItem> priceDimensions { get; set; }
        public TermAttributes termAttributes { get; set; }
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
    
    public class TermAttributes
    {
        public string LeaseContractLength { get; set; }
        public string OfferingClass { get; set; }
        public string PurchaseOption { get; set; }
    }
