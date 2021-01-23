    public class MyUser : IdentityUser<int,MyLogin,MyUserRole,MyUserClaim>
    {
         public virtual MyUserProfile Profile { get; set; }
    }
    
    public class MyUserProfile
    {
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public MyUser User { get; set; }
    }
