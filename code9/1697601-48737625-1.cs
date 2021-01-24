    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager() : base(new UserStore<ApplicationUser>(new MyDbContext()))
        {
            var dataProtectionProvider = Startup.DataProtectionProvider;
            this.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
    
            // do other configuration
        }
    }
