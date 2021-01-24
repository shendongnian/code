    public class RootObject
    {
        public Channel channel { get; set; }
        public List<Feed> feeds { get; set; }
    }
    public class Channel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string field1 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string elevation { get; set; }
        public int last_entry_id { get; set; }
    }
    
    public class Feed
    {
        public DateTime created_at { get; set; }
        public int entry_id { get; set; }
        public string field1 { get; set; }
    }
