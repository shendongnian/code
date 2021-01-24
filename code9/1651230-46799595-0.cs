    public class Y : Context
    {
        public DbSet<B> B { get; set; }
    
        public DbSet<C> C { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BConfiguration());
            modelBuilder.Configurations.Add(new CConfiguration());
            modelBuilder.Ignore<A>(); 
            base.OnModelCreating(modelBuilder);
        }
    }
