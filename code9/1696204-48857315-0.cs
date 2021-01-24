    public interface IUserContextProvider {
      User GetCurrentUser();
    }
    public class MvcUserContextProvider : IUserContextProvider {
      
      protected IHttpContextAccessor Accessor { get; set; }
      
      public MvcUserContextProvider(IHttpContextAccessor accessor) {
        Accessor = accessor;
      }
      public User GetCurrentUser() {
        //  Probably need some error handling and Special case pattern when
        // context is null.
        return (User) Accessor.HttpContext.User.Identity;
      }
    }
    public interface IEntityFrameworkOverrides {
      void EntityInitializing(ModelBuilder modelBuilder, IMutableEntityType entity);
      void EntityChanged(EntityEntry entity);
    }
    public abstract class UserAwareOverride : IEntityFrameworkOverrides {
      protected IUserContextProvider UserProvider { get; private set; }
      protected UserAwareOverride(IUserContextProvider userProvider)
      {
        UserProvider = userProvider;
      }
      public abstract void EntityInitializing(ModelBuilder modelBuilder, IMutableEntityType entity);
      public abstract void EntityChanged(EntityEntry entity);
    }
    public class ApplicationContext : IdentityDbContext<User> {
      private static bool ConfigurOverridesSet = false;
      protected static readonly List<IEntityFrameworkOverrides> EFOverrides = new List<IEntityFrameworkOverrides>();
      public static void ConfigureOverrides(IEnumerable<IEntityFrameworkOverrides> overrides) {
        if (ConfigurOverridesSet) {
         throw new NotSupportedException("Cannot set overrides on SplitFamContext More than once.");
        }
        EFOverrides.AddRange(overrides);
        ConfigurOverridesSet = true;
      }
      public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        :base(options) { }
    }
