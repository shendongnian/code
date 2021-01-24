    public class Comment
    {
        public int CommentId { get; set; }
    
        [MaxLength(280)]
        public string Content { get; set; }
    
        public long time { get; set; } // unix time / epoch time
    
        [JsonIgnore]
        [IgnoreDataMember]
        public string user_id { get; set; }
        public virtual CommentUser CommentUser { get; set; }
    
        [JsonIgnore]
        [IgnoreDataMember]
        public int? ThreadId { get; set; } 
                  ^ //set this as nullable
    
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Thread Thread { get; set; }
    
        public virtual List<Comment> Comments { get; set; }
    
    }
