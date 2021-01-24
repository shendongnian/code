    public class Post
    {
        public int ID { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }
        public PostContent Content { get; set; }
    }
    
    public class PostContent
    {
        public int ID { get; set; }
        public string Content { get; set; }
    }
