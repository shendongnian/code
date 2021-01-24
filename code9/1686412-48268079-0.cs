    [DataContract]
    public class CompositeType
    {
        public bool _flag = true;
    
        [DataMember(EmitDefaultValue = false)]
        public decimal? Value { get; set; }
    }
