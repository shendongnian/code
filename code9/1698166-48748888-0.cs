        public class SubscriptionDetails
    {
        public DateTime connectDate { get; set; }
        public string application { get; set; }
        public string subtype { get; set; }
        public string authorizedEntity { get; set; }
        public string connectionType { get; set; }
        public string platform { get; set; }
        public Dictionary<string, topicItems>   rel { get; set; }
    }
    public class topicItems : Dictionary<string, topicData> { }
    public class topicData
    {
        public DateTime addDate { get; set; }
    }
