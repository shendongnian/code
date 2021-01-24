    [DataContract(Namespace = "http://mycompany.com/MyProduct/Operations")]
    public class PingDataConfirmation
    {
        [DataMember(IsRequired = true, Order = 1)]
        public string SourceGuid { get; set; }
        [DataMember(IsRequired = true, Order = 2)]
        public string Guid { get; set; }
        [DataMember(IsRequired = true, Order = 3)]
        public DateTime CreationTime { get; set; }
    }
