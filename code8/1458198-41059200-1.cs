    [DataContract(Namespace = "Microsoft.ServiceBus.Messaging")]
    [KnownType(typeof(Dictionary<string, object>))]
    public class EventData
    {
        [DataMember]
        public IDictionary<string, object> SystemProperties { get; set; }
    
        [DataMember]
        public IDictionary<string, object> Properties { get; set; }
    
        [DataMember]
        public byte[] Body { get; set; }
    }
