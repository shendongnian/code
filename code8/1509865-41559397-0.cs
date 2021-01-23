    public class ApplicationUserStore :
        UserStore<ApplicationUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, ApplicationUserClaim>,
        IUserStore<ApplicationUser>
    {
        public ApplicationUserStore(DbContext context) : base(context)
        {
        }
    }
