    public class Post
    {
        public int Id{ get; set; }
        public ICollection<Comment> Comments { get; set; }
        //other properties 
        //Unmapped property
        public int NumberOfComments { get { return Comments.Count(); } }
    }
