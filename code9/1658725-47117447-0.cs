    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        //public virtual ICollection<Common> CommonUsers { get; set; }
        public virtual Administrator Administrators { get; set;}
    }
    public class Administrator : Usuario
    {
        //Primary key is required but not defined
        [ForeignKey("User")]
        public int ID { get; set; }
        //same admin role applies to many users
        public virtual ICollection<User> User { get; set; }
    }
