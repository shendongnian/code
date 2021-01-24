     class dbTestContext: DbContext
        {
    
            //=below= connection string now has connection string identifier as argument
            public dbTestContext() : base("dbTestConnectionString") { }  
    
            public DbSet<Test> dbTest { get; set; }     
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                
                modelBuilder.Entity<Test>().ToTable("tblTest", "public");            
    
                
                modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
            }
        }
    }
