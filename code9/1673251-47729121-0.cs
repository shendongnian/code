    public class MessageGroup
    {
        public int MessageId { get; set; }
        public virtual Message Message { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
