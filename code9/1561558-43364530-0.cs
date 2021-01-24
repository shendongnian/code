    public class Topic
    {
        public string TopicName { get; set; }
        public int OrdinalOrder { get; set; }
    }
    List<Topic> topics = JsonConvert.DeserializeObject<List<Topic>>(strTopicset);
