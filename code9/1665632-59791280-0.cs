    public class Sport : BaseEntity
    {
        public string Name { get; set; }
    
        public int UserId { get; set; }
        public User User { get; set; }  //This is the cause of your circular reference
    }
    
    public class User : BaseEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    
        public List<Sport> Sports { get; set; }
    }
