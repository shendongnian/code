    public namespace Microsoft.AspNet.Identity.EntityFramework
    {
    //
    // Summary:
    //     EntityFramework based user store implementation that supports IUserStore, IUserLoginStore,
    //     IUserClaimStore and IUserRoleStore
    //
    // Type parameters:
    //   TUser:
    public class UserStore<TUser> : UserStore<TUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUserStore<TUser>, IUserStore<TUser, string>, IDisposable where TUser : IdentityUser
    {
        //
        // Summary:
        //     Default constuctor which uses a new instance of a default EntityyDbContext
        public UserStore();
        //
        // Summary:
        //     Constructor
        //
        // Parameters:
        //   context:
        public UserStore(DbContext context);
       }
    }
