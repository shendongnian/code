    [DataContract]
    public class RQFieldPatch<T>
    {
        [DataMember(Name = "value")]
        public T Value { get; set; }
    }
