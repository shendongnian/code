    [Table("MyUser ")]
    public class MyUser : IdentityUser<int,MyLogin,MyUserRole,MyUserClaim>
    {
         public virtual MyUserProfile Profile { get; set; }
    }
    [Table("MyUser ")]
    public class MyUserProfile
    {
         [Key]
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
    }
