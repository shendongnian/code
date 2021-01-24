        public class ApplicationDbContext
        {
            public ApplicationDbContext(DbContextOptions options) : base(options) 
            {
            }
            // The call of the base constructor via ": base()" is still required
            public ApplicationDbContext(DbContextOptions options) : base() 
            {
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("connectionStringHere"));
                base.OnConfiguring(optionsBuilder);
            }
        }
