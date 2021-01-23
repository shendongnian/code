     [DataContract]
     public class Rootobject
    {
        [DataMember]
        public int total_grand { get; set; }
        [DataMember]
        public int total_billable { get; set; }
        [DataMember]
        public List<Total_Currencies> total_currencies { get; set; }
        [DataMember]
        public int total_count { get; set; }
        [DataMember]
        public int per_page { get; set; }
        [DataMember]
        public List<Datum> data { get; set; }
    }
    [DataContract]
    public class Total_Currencies
    {
        [DataMember]
        public string currency { get; set; }
        [DataMember]
        public float amount { get; set; }
    }
    [DataContract]
    public class Datum
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int? pid { get; set; }
        [DataMember]
        public int? tid { get; set; }
        [DataMember]
        public int uid { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public DateTime start { get; set; }
        [DataMember]
        public DateTime end { get; set; }
        [DataMember]
        public DateTime updated { get; set; }
        [DataMember]
        public int dur { get; set; }
        [DataMember]
        public string user { get; set; } 
        [DataMember]
        public bool use_stop { get; set; }
        [DataMember]
        public object client { get; set; }
        [DataMember]
        public string project { get; set; }
        [DataMember]
        public string project_color { get; set; }
        [DataMember]
        public string project_hex_color { get; set; }
        [DataMember]
        public string task { get; set; }
        [DataMember]
        public float billable { get; set; }
        [DataMember]
        public bool is_billable { get; set; }
        [DataMember]
        public string cur { get; set; }
        [DataMember]
        public string[] tags { get; set; }
    }
