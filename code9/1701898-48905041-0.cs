        public class CommonDbContext : DbContext
        {
            public CommonDbContext(DbContextOptions<CommonDbContext> options)
                : base(options)
            {
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=DBName;User ID=user;Password=pwd;Connection Timeout=60");
            }
        }
