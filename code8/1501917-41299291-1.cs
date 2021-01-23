    public MyDbContext : DbContext
    {
        public DbSet<MyDerived1Item> MyDerived1Items {get; set;}
        public DbSet<MyDerived2Item> MyDerived2Items {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
            modelBuilder.Entity<MyDerived1Item>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("MyDerived1Items");
            });
 
            modelBuilder.Entity<MyDerived2Item>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("MyDerived2Items");
            });  
        }
    }  
