    public class User
    {
        public int UserId { get; set; }
        public virtual ICollection<Friend> MainUserFriends { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
    }
