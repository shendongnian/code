    public class Member
    {
        public string id { get; set; }
        public string email_address { get; set; }
        public string status { get; set; }
        public Dictionary<string, object> merge_fields { get; set; }
        public Dictionary<string, bool> interests { get; set; }
    }
