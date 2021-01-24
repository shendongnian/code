        using Microsoft.AspNetCore.Identity;
        using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
        using Microsoft.EntityFrameworkCore;
        using Phenomenal.WebApp.Domain.BlogModels;
    
        namespace Phenomenal.WebApp
        {
            public class PhenomenalContext : IdentityDbContext<IdentityUser>
            {
               public PhenomenalContext(DbContextOptions<PhenomenalContext> options)
                   :base(options)
               {
                
            }
    
            public DbSet<BlogPost> BlogPosts { get; set; }
            public DbSet<Comment> Comments { get; set; }
    
    
            
        }
    }
