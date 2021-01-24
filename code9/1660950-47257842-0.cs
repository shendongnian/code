    public class Actor  
    {       
        public int Id { get; set; }       
        public string Username { get; set; }
    
        [InverseProperty("AboutActor")]
        public virtual ICollection<Comment> CommentsAbout { get; set; }
        [InverseProperty("FromActor")]
        public virtual ICollection<Comment> CommentsFrom { get; set; }
    
        [InverseProperty("ToActor")]
        public virtual ICollection<Message> MessagesTo { get; set; }
        [InverseProperty("FromActor")]
        public virtual ICollection<Message> MessagesFrom { get; set; }
    }
