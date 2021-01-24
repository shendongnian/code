    public class ResponseType
    {
        public Query Query { get; set; }
        public Request Request { get; set; }
        public Seller Seller { get; set; }
        public Prices Prices { get; set; }
        public Offer Offer { get; set; }
        public Brand Brand { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Item Item { get; set; }
        public Result Result { get; set; }
        public RootObject RootObject { get; set; }
    }
    public class Query
    {
        public string q { get; set; }
        public object sku { get; set; }
        public int limit { get; set; }
        public object reference { get; set; }
        public object mpn_or_sku { get; set; }
        public string mpn { get; set; }
        public object brand { get; set; }
        public string __class__ { get; set; }
        public int start { get; set; }
        public object seller { get; set; }
    }
    public class Request
    {
        public bool exact_only { get; set; }
        public string __class__ { get; set; }
        public List<Query> queries { get; set; }
    }
    public class Seller
    {
        public string display_flag { get; set; }
        public bool has_ecommerce { get; set; }
        public string name { get; set; }
        public string __class__ { get; set; }
        public string homepage_url { get; set; }
        public string id { get; set; }
        public string uid { get; set; }
    }
    public class Prices
    {
        public List<List<object>> USD { get; set; }
        public List<List<object>> JPY { get; set; }
        public List<List<object>> CNY { get; set; }
    }
    public class Offer
    {
        public string sku { get; set; }
        public string packaging { get; set; }
        public string on_order_eta { get; set; }
        public string last_updated { get; set; }
        public int? order_multiple { get; set; }
        public int in_stock_quantity { get; set; }
        public string eligible_region { get; set; }
        public int? moq { get; set; }
        public int? on_order_quantity { get; set; }
        public object octopart_rfq_url { get; set; }
        public string __class__ { get; set; }
        public Seller seller { get; set; }
        public string product_url { get; set; }
        public object factory_order_multiple { get; set; }
        public string _naive_id { get; set; }
        public int? factory_lead_days { get; set; }
        public Prices prices { get; set; }
        public bool is_authorized { get; set; }
        public bool is_realtime { get; set; }
    }
    public class Brand
    {
        public string homepage_url { get; set; }
        public string __class__ { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }
    public class Manufacturer
    {
        public string homepage_url { get; set; }
        public string __class__ { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }
    public class Item
    {
        public List<Offer> offers { get; set; }
        public string uid { get; set; }
        public string mpn { get; set; }
        public List<object> redirected_uids { get; set; }
        public Brand brand { get; set; }
        public string octopart_url { get; set; }
        public string __class__ { get; set; }
        public Manufacturer manufacturer { get; set; }
    }
    public class Result
    {
        public List<Item> items { get; set; }
        public int hits { get; set; }
        public string __class__ { get; set; }
        public object reference { get; set; }
        public object error { get; set; }
    }
    public class RootObject
    {
        public int msec { get; set; }
        public Request request { get; set; }
        public string __class__ { get; set; }
        public List<Result> results { get; set; }
    }
