    [DataContract]
    public class PrimaryData
    {
        [DataMember(Name = "Data", Order = 0, IsRequired = true)]
        public Dictionary<string, object> Data { get; set; }
    }
