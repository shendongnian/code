    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    
    public class Role : IdentityRole<Guid,UserRole>
    public class UserLogin : IdentityUserLogin<Guid>
    public class UserRole : IdentityUserRole<Guid>
    public class UserClaim : IdentityUserClaim<Guid>
