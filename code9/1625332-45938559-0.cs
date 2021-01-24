    public class LoginRecord
    {
      [Key]
      public int LoginRecordID {get; set;}
      public User User { get; set; }
      public int UserId { get; set; }
      public DateTime LastLogin { get; set; }
      public int LoginCount { get; set; } 
    }
