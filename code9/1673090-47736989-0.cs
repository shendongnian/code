    public class Message 
    {
        public string Content { get; set; } // Text of the message
        public List<Message> Replies { get; set; } = new List<Message>(); // Its replies
        public Message(string text)
        {
            Content = text;
        }
        public void AddReply(Message m)
        {
             Replies.Add(m);
        }
    } 
