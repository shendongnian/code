    class User {
        public ICollection<Message> MessagesSent { get; } // bound to Messages.SenderUserId
        
        public ICollection<Message> MessagesReceived { get; } // bound to MessageUsers.MessageId+UserId as a M:M relationship
    }
    class Message {
        public User Sender { get; }
        public ICollection<User> Recipients { get; } // bound to MessageUsers.MessageId+UserId as a M:M relationship
    }
