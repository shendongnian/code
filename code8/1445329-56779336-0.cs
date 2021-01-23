    public class DataContext:DbContext
        {
            public DataContext(DbContextOptions<DataContext> options):base(options)
            {
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
    
            public virtual DbSet<Tbl_Student> Tbl_Students { get; set; }
            
        } 
