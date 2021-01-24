    public class Comment
    {
        /// <summary>
        /// gets the child comments
        /// </summary>
        public IList<Comment> Children { get; } = new List<Comment>();
    
        public int Id { get; set; }
        public int Depth { get; set; }
        public string Body { get; set; }
        public int? ReplyId { get; set; }
    }
    
