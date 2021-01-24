    public class User {
         [Key]
         public int UserId { get; set; }
    
         public virtual Sub_User SubUser { get; set; }
    }
    public class Sub_User{
         [Key]
         public int Sub_User_ID { get; set; }
         
         [ForeignKey("User")]
         public int UserID { get; set; }
    
         public virtual User User { get; set; }
    }
