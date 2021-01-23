    public class Recipient
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string recipient_type { get; set; }
        public bool has_completed { get; set; }
        public string id { get; set; }
    }
    
    public class Field
    {
        public string assignee { get; set; }
        public string title { get; set; }
        public string uuid { get; set; }
        public object value { get; set; }
        public string name { get; set; }
    }
    
    public class SentBy
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string id { get; set; }
        public object avatar { get; set; }
    }
    
    public class CreatedBy
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string id { get; set; }
        public object avatar { get; set; }
    }
    
    public class ActionBy
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }
    
    public class Metadata
    {
    }
    
    public class Data
    {
        public string status { get; set; }
        public string name { get; set; }
        public List<Recipient> recipients { get; set; }
        public string date_modified { get; set; }
        public List<Field> fields { get; set; }
        public List<object> tags { get; set; }
        public SentBy sent_by { get; set; }
        public CreatedBy created_by { get; set; }
        public List<object> tokens { get; set; }
        public string action_date { get; set; }
        public ActionBy action_by { get; set; }
        public string date_created { get; set; }
        public string id { get; set; }
        public Metadata metadata { get; set; }
    }
    
    public class RootObject
    {
        public Data data { get; set; }
        public string @event { get; set; }
    }
