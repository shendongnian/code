      public class PostAndComments
    {
        public int IDPost { get; set; }
        public int IDComment { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDateTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Post Post { get; set; }
    }
