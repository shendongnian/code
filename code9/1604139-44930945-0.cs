    public class Record
    {
        public string @class {get; set;}
        public string id { get; set; }
        public List<RecordField> fields { get; set; }
        public Dictionary<string,string> links { get; set; }
    }
    
    public class RecordField
    {
        // fields from first object in the array
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string domain { get; set; }
        public int month { get; set; }
        public bool secure { get; set; }
        public List<string> filters { get; set; }
        public int user_count { get; set; }
    
        // fields from second object in the array
        public int first_name { get; set; }
        //...
    }
