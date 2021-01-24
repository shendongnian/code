    public class Blog
    {
        public int Id { get; set; }
        public IList<Post> Posts { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
    }
