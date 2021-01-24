    public class Sub_User{
        [Key]
        public int Sub_User_ID { get; set; }
    
        [Required]
        public virtual User User { get; set; }
    }
