    class DbC : DbContext
    {
        public DbC()
        {
        }
        public DbSet<Blog> Blogs { get; set; }
    }
    class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
    class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
