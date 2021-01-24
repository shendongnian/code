    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    
        public virtual AccessToken AccessToken { get; set; }
    }
    
    public class AccessToken
    {
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Token { get; set; }
    
        public virtual User User { get; set; }
    }
