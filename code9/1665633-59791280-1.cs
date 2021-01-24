    public class Sport : BaseEntity
    {
        public string Name { get; set; }
    
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }  //fixed
    }
    
    public class User : BaseEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    
        public List<Sport> Sports { get; set; }
    }
