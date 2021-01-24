    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
