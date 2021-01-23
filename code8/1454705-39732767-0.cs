    [DataContract]
    public class Update_DB
    {
        [DataMember(Name = "appname", IsRequired = true)]
        public string appname { get; set; }
        [DataMember]
        public string key { get; set; }
        [DataMember(Name = "data", IsRequired = true)]
        public List<dynamic> data { get; set; }
        [DataMember]
        public string updateId { get; set; }
        [DataMember]
        public string updateTS { get; set; }
        [DataMember]
        public string creationUser { get; set; }
    }
