    [DataContract]
    public class Thing
    {
        [DataMember(Name = "@context")]
        public string Context => "http://schema.org";
        public bool ShouldSerializeContext() { return this is Organization; }
    }
