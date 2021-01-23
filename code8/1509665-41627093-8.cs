    public class IdentityUserManager : UserManager<IdentityUser> {
        private IdentityUserManager()
            : base(new UserStore<IdentityUser>(MyIdentityDbContext.Create())) {
            //...other code removed for brevity
            var dataProtectionProvider = Auth.DataProtectionProvider;
            if (dataProtectionProvider != null) {
                this.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(dataProtectionProvider.Create("UserToken"));
            }
        }
        public static IdentityUserManager Create() {
            return new IdentityUserManager();
        }
    }
