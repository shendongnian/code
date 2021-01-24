    public class UserAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
    
        public ICollection<Challenge> Challenges { get; set; }
    }
