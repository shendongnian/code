    public ActionResult Index()
    {
      return new TopicAndDetails {
        Topics = db.Topics.ToList(),
        TagTopics = db.TagTopics.ToList()
      };
    }
    public partial class TopicAndDetails
    {
        public List<Topic> Topics { get; set; }
        public List<TagTopic> TagTopics { get; set; }
    }
