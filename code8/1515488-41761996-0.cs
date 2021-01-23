    public class IdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public IdentityAdminManagerService() 
            : base("IdServer3")
        {
        }
    }
    public static class IdentityAdminManagerServiceExtensions
    {
        public static void Configure(this IdentityAdminServiceFactory factory)
        {
            factory.IdentityAdminService = new Registration<IIdentityAdminService, IdentityAdminManagerService>();
        }
    }
