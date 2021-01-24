    [DataContract]
    [KnownType(typeof(AuthorizationRequest))]
    public class Message
    {
        [DataMember(Name = "technical", Order = 1)]
        public Technical Technical;
    
        [DataMember(Name = "payload", Order = 2)]
        public object Payload;
    }
