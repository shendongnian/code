    public class ApplicationUser : IdentityUser<Guid>
    {
    }
    
    public class ApplicationRole : IdentityRole<Guid>
    {
        
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        Public ApplicationDbContext(DbContextOptions < ApplicationDbContext > Options): Base (Options)
        {
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
    
            // For Guid Primary Key
            builder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
    
            // For int Primary Key
            //builder.Entity<ApplicationUser>().Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    
        // Add application services.
        services.AddTransient<IEmailSender, EmailSender>();
    
        services.AddMvc();
    }
    
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink<T>(this IUrlHelper urlHelper, T userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    
        public static string ResetPasswordCallbackLink<T>(this IUrlHelper urlHelper, T userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
    
    ....
    var info = await _signInManager.GetExternalLoginInfoAsync(user.Id.ToString());
