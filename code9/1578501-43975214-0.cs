    public class Input
    {
        [DataMember]
        public string fileName { get; set; }
        [DataMember]
        public DateTime createdDate{ get; set; }
        [DataMember]
        public DateTime modifiedDate{ get; set; }
        [DataMember]
        public byte[] fileContents { get; set; }
    .
    .
    }
