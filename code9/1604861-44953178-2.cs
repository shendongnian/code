    [DataContract]
    public class File
    {
        // excluded from serialization
        // does not have DataMemberAttribute
        public Guid Id { get; set; }
     
        [DataMember]
        public string Name { get; set; }
    
        [DataMember]
        public int Size { get; set; }
    }
