    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        [ForeignKey("BlogForeignKey")]
        public List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogForeignKey { get; set; }
    }
