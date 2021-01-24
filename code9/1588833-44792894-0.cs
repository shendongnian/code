    public class ApplicationDbContext : DbContext>
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        #endregion
    }
