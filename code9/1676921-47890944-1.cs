    public class AuthContext : IdentityDbContext<IdentityUser> //this Inheritance
    {
        public AuthContext()
            : base("AuthContext")
        {
 
        }
    }
