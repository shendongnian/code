    public class Rootobject
    {
        public string usr_id { get; set; }
        public string patient_id { get; set; }
        public Execution[] executions { get; set; }
    }
    
    public class Execution
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public bool delete { get; set; }
    }
