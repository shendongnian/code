    public class User {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public static implicit operator User(bool v) {
            throw new NotImplementedException();
        }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual List<User> friends { get; set; }
    }
    public class Message {
        [Key]
        public int ID { get; set; }
        public virtual User Sender { get; set; }
        public virtual ICollection<User> Recipients { get; set; }
        public string content { get; set; }
    }
