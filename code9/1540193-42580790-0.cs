    [DataContract]
    public class DataClass
    {
        [DataMember]
        public string Name { get; set; }
    //Ignored
        public string Value { get; set; }
        public int SortOrder { get; set; }
    }
