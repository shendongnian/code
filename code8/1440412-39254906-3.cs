    public class Rootobject
    {
        public string status { get; set; }
        public Price[] prices { get; set; }
    }
    public class Price
    {
        public string market_hash_name { get; set; }
        public string price { get; set; }
        public int created_at { get; set; }
    }
