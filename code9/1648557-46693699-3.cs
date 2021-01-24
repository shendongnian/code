    public class Data
    {
        public string name { get; set; }
        public StatusId statusId { get; set; }
        public string tdMnemo { get; set; }
        public ProductTraded[] productsTradedOnDesks { get; set; }
    }
    
    public class StatusId
    {
        public string mnemo { get; set; }
        public string label { get; set; }
    }
    
    public class ProductTraded
    {
        public int secptdAssetClassId { get; set; }
        public string secptdAssetClassName { get; set; }
        public int secptdInstrumentId { get; set; }
        public string secptdInstrumentName { get; set; }
        public ProductMapDetail[] sectptdVlkMap { get; set; }
    }
    
    public class ProductMapDetail
    {
        public int secpVlkmVlkId { get; set; }
        public string secpVlkmVlkLabel { get; set; }
    }
