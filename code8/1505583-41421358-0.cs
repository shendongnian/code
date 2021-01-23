    public class MyDBContext: DbContext {
        private readonly IHostingEnvironment env;
        public MyDBContext(IHostingEnvironment env) : base() {
            this.env = env;
        }
    
        public IConfigurationRoot Configuration { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Path.Combine(env.ContentRootPath, "..\\..\\.."))
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SQLCN"));// @"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
    
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
