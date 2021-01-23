    [DataContract]
    public class CompositeType
    {
        [DataMember]
        public string userID { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string envName { get; set; }
        [DataMember]
        public string newDate { get; set; }
        [DataMember]
        public string newTime { get; set; }
    }
