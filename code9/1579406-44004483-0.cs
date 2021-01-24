    public class Root
    {
        public ProductMeta[] meta_data { get; set; }
    }
    public class ProductMeta
    {
        public int? id { get; set; }
        public string key { get; set; }
        public Dictionary<string, ProductPriceGroup> value { get; set; }
    }
    public class ProductPriceGroup
    {
        public ProductGroupPrice group_price { get; set; }
    }
    public class ProductGroupPrice
    {
        public string price { get; set; }
        public object price_type { get; set; }
    }
