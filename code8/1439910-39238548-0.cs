    public class Picture
    { 
        [Key]
        public int Id { get; set; }
        [ForeignKey("NewsId")]
        public int NewsId { get; set; }
        public virtual News News { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }        
        public virtual Post Post { get; set; }        
    }
    public class News
    {
        [Key]
        public int Id { get; set; }
        public virtual Picture Picture { get; set; }
    }
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public virtual Picture Picture { get; set; }
    }
