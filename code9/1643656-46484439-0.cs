    public class ResponseModel
    {
        public int id { get; set; }
        public string zoneid { get; set; }
        public object parent_id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public int ttl { get; set; }
        public object priority { get; set; }
        public string type { get; set; }
        public List<string> regions { get; set; }
        public bool system_record { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
    public class RootObject
    {
        public ResponseModel data { get; set; }
    }
