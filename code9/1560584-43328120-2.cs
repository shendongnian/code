    public class Session
    {
        [Key]
        [ForeignKey("User")]
        public long Id { get; set; }
        ...
        public virtual User User { get; set;}
    }
    
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        ...
        public virtual Session Session { get; set;}
    }
