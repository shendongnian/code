    public class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
    
        public ICollection<Post> Posts { get; set; }
    }
