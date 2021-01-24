    public class TriggerRequest
    {
        public string reference { get; set; }
        public TriggerRequestFields fields { get; set; }
    }
    public class TriggerRequestFields
    {
        public string cust {get;set;}
        ...
        public TriggerRequestLines lines {get;set;}
    }
    public class TriggerRequestLines
    {
        public string line {get;set;}
        public string data {get;set;}
    }
