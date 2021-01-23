     [DataContract]
    [KnownType(typeof(List<Dictionary<string, object>>))]
    public class Foo
    {
        [DataMember]
        public IDictionary<String, Object> Inputs { get; set; }
    }
