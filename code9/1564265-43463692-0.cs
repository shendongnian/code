    public interface ITestDbContext
    {
        DbSet<Episode> Episodes { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        // ....
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
