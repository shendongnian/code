public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Outlet>()
                .HasIndex(o => new { o.OutletRef });
        }
    }
    
This adds the required unique index in the database.
What it doesn't do though is provide the ability to specify a custom error message.
