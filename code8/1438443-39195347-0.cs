    public class RootObject
    {
        public string id { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string assignee { get; set; }
        public List<string> notes { get; set; }
        public string created_at { get; set; }
        public Dictionary<int,Item> items { get; set; }
    }
    
    public class Item
    {
        public bool minimized { get; set; }
        public Sku sku { get; set; }
    }
    
    public class Sku
    {
        public int partner_id { get; set; }
        public int type_id { get; set; }
    	[JsonIgnore]
        public object errors { get; set; }
    }
