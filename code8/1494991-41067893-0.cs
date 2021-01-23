    [DataContract]
    [KnownType(typeof(Type_X))]
    [KnownType(typeof(Type_Y))]
    public abstract class BaseClass
    {
        [DataMember]
        public Dictionary<string, object> BaseDictionary { get; set; }
        public BaseClass()
        {
            BaseDictionary = new Dictionary<string, object>();
        }
    }
