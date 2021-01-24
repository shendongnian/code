    [DataContract]
    public class Wrapper<T> where T : Body
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "resource")]
        public string Resource { get; set; }
        [DataMember(Name = "body")]
        public string T Body { get; set; } 
    }
    [DataContract]
    public class Body
    {
        [DataMember(Name = "bodyproperty")]
        public string BodyProperty { get; set; }
    }
