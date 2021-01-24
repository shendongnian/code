    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    }
