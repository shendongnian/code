    [DataContract]
    public class SearchResult
    {
        [DataMember(Name = "@search.score")]
        public float SearchScore { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Domain { get; set; }
        [DataMember]
        public string RuleName { get; set; }
        [DataMember]
        public string Log { get; set; }
        [DataMember]
        public string ChangeId { get; set; }
        [DataMember]
        public string ParentId { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember(Name = "@odata.context")]
        public string Context { get; set; }
        [DataMember]
        public List<SearchResult> value { get; set; }
    }
