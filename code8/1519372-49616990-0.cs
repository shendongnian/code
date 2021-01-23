    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Post> Posts { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    
        public virtual Blog Blog { get; set; }
    }
