    public class PostExtraData
    {
        public Post post { get; set; }
        public int NumberOfComments { get; set; } 
    }
    
    public class Post
    {
        public int Id { get; set; }
        public ICollection<Comment> Comments { get; set; }
    
        //other properties 
    
    }
    
    public class Comment
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    
        // other properties
    }
