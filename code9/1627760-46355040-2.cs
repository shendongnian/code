    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>
        , ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        ...
    }
    public void ConfigureServices(IServiceCollection services)
    {
       ...
       services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
       ...
    }
    public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
    public async void Initialize()
        {
            _context.Database.EnsureCreated();
            if (!_context.Roles.Any(r => r.Name == SharedConstants.Role.ADMINISTRATOR))
                await _roleManager.CreateAsync(new ApplicationRole(SharedConstants.Role.ADMINISTRATOR));
        }            
