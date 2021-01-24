    	public class RoleManager<TRole> : RoleManager<TRole, string> where TRole : class, IRole<string>
        {
            //
            // Summary:
            //     Constructor
            //
            // Parameters:
            //   store:
            public RoleManager(IRoleStore<TRole, string> store);
        }
    	
           public class ApplicationRoleManager : RoleManager<ApplicationRole>
            {
                public ApplicationRoleManager(
                    IRoleStore<ApplicationRole, string> roleStore)
                    : base(roleStore)
                {
                }
                public static ApplicationRoleManager Create(
                    IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
                {
                    return new ApplicationRoleManager(
                        new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
                }
         }
