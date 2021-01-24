    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder) => 
                optionsBuilder.UseSqlite("your connection string");
    }
