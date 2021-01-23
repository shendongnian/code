    public class CommentUserProfileJoin
    {
        public int ID { get; set; }
        public string CommentText { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public int InappropriateFlags { get; set; }
        public int PostId { get; set; }
        public string ControllerName { get; set; }
        public int ReplyTo { get; set; }
        public bool replied { get; set; }
        public int UserProfileId { get; set; }
    }
