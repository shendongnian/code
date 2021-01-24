    public class Claim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CommentDiscussion CommentDiscussion { get; set; }
    }
    public class ForumThread
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CommentDiscussion CommentDiscussion { get; set; }
    }
    public class CommentDiscussion
    {
        public int Id { get; set; }
        public int? ClaimId { get; set; }
        public Claim Claim { get; set; }
        public int? ForumThreadId { get; set; }
        public ForumThread ForumThread { get; set; }
    }
