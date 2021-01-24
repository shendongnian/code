    public class User
    {
        [Key]
        public int UserId { get; set; }
    
        public string Name { get; set; }
    
        public virtual Sub_User SubUser { get; set;}
    }
    public class Sub_User
    {
        [Key]
        public int Sub_User_ID { get; set; }
        public string Name { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
