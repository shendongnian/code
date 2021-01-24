    public class UserAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
    
        public ICollection<Challenge> Challenges { get; set; }
    }
        public class Challenge
    {
       public int Id { get; set; }
       public string ChallengeId {get; set;}
       public string Name { get; set; }
       public string Description { get; set; }
    
       public ICollection<UserAccount> UserAccounts { get; set; }
    }
