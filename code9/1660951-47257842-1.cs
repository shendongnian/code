    public class Comment
    {        
        //other stuff...
        public int AboutActorId { get; set; }        
        public int FromActorId { get; set; }
        public virtual Actor AboutActor { get; set; }        
        public virtual Actor FromActor { get; set; }
    }
    
    public class Message
    {
        //other stuff...
        public int ToActorId { get; set; }        
        public int FromActorId { get; set; }
        public virtual Actor ToActor { get; set; }
        public virtual Actor FromActor { get; set; } 
    }
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
