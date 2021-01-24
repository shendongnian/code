    [Table("UserProfile")]
    public class UserProfile
    {
      [key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public int UserId { get; set; }
      public string UserName { get; set; }
      public string LastName { get; set; }
      public string FirstName { get; set; }
      public string Email { get; set; }
      public bool IsActive { get; set; }
    }
