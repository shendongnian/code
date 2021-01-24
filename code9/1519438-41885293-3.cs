    public interface IUserManager<TUser, TKey> : IDisposable
        where TUser : class, Microsoft.AspNet.Identity.IUser<TKey>
        where TKey : System.IEquatable<TKey> {
        //...include all the properties and methods to be exposed
        IQueryable<TUser> Users { get; }
        Task<TUser> FindByEmailAsync(string email);
        Task<TUser> FindByIdAsync(TKey userId);
        //...other code removed for brevity
    }
    public IUserManager<TUser> : IUserManager<TUser, string>
        where TUser : class, Microsoft.AspNet.Identity.IUser<string> { }
    public IApplicationUserManager : IUserManager<ApplicationUser> { }
