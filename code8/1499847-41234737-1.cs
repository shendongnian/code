    [DataContract]
    public class Thing
    {
        // Don't mark this property with [DataMember]
        public string ThingName { get; set; }
        [DataMember(Name = "property1")]
        public int Property1 { get; set; }
        [DataMember(Name = "property2")]
        public string Property2 { get; set; }
    }
