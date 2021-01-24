    [DataContract(Name = "Root", Namespace = "http://www.MyNamespace.com")]
    public class RootObject
    {
        [DataMember]
        public NestedObject NestedObject { get; set; }
    }
    [DataContract(Name = "Nested", Namespace = "http://www.MyNamespace.com")]
    public class NestedObject
    {
        [DataMember]
        public string SensitiveData { get; set; }
        [DataMember]
        public string PublicData { get; set; }
    }
