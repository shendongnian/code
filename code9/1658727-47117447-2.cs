    public class Usuario // User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        //public virtual ICollection<Common> CommonUsers { get; set; }
        //public virtual ICollection<Administrator> Administrators { get; set;}
        //define 1-to-1(0)
        public virtual Common CommonUsers { get; set; }
        public virtual Administrator Administrators { get; set;}
    }
    public class Administrator : Usuario
    {
        [ForeignKey("User")]
        public int ID { get; set; }
        public virtual User User { get; set; }
    }
