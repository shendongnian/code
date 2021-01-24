    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    public static class Seed
    {
        public static void Initialize(IServiceProvider provider)
        {
            var _context = provider.GetRequiredService<ApplicationDbContext>();
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            
            
        }
    }
