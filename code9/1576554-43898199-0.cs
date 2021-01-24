    public ActionResult Index()
    {
      return db.Topics.Select(t=>new TopicAndDetails {Topic=t})
        .Concat(db.TagTopics.Select(tt=>new TopicAndDetails {TagTopic=tt));
    }
    public partial class TopicAndDetails
    {
        public Topic Topic { get; set; }
        public TagTopic TagTopic { get; set; }
    }
