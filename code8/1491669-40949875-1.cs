        In order to extend asp.net identity user and keep the things simple, please update IdentityModels.cs with following code: 
    
    //CODE
      
        using System.Data.Entity;
        using System.Security.Claims;
        using System.Threading.Tasks;
        using Microsoft.AspNet.Identity;
        using Microsoft.AspNet.Identity.EntityFramework;
        using System.Data.Entity.Migrations;
        
    namespace WebApplication.Models
    {
        // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
        public class ApplicationUser : IdentityUser
        {
            public string Name { get; set; }
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }
    
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApplicationDbContextConfiguration>());
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
                modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
                modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
                modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            }
    
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    
    
    
        internal sealed class ApplicationDbContextConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
        {
            public ApplicationDbContextConfiguration()
            {
                           
                ContextKey = "WebApplication.Models.ApplicationDbContext"; //Retrieved from the database table dbo.__MigrationHistory
    
    #if DEBUG
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
    #else
                    AutomaticMigrationsEnabled = false;
                    AutomaticMigrationDataLossAllowed = false;
    
    #endif
            }
    
            protected override void Seed(ApplicationDbContext context)
            {
                base.Seed(context);
            }
        }
    } 
    
    
    The output is: 
    
