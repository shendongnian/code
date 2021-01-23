    public class PostDetail
    {
        public string name { get; set; }
        public string pic_large { get; set; }
        public string id { get; set; }
    }
    
    public class Likes
    {
        public List<PostDetail> data { get; set; }
    }
    
    public class Post
    {
        public string id { get; set; }
        public Likes likes { get; set; }
    }
    
    public class RootObject
    {
        public List<Post> data { get; set; }
    }
