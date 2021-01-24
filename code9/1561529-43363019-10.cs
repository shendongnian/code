    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    namespace SampleApp.Models
    {
        // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
        public class ApplicationUser : IdentityUser
        {
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
    		//Extra column added to auto generated Table by Code First approach (ASPNETUSERS) by Entity Framework
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DOB { get; set; }
            public string Sex { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Mobile { get; set; }
        }
    
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    }
