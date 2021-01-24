    [Serializable()]
    [DataContract]
    public class RootObjectClass
    {
        [DataMember()]
        public bool status { get; set; }
        [DataMember()]
        public string error_code { get; set; }
        [DataMember()]
        public string error_message { get; set; }
        [DataMember()]
        public Dictionary<string,Contact> data { get; set; }
    }
