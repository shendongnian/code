    public class TestContext : DbContext
        {
            public DbSet<TestRecord> Tests { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Asmodat_FxTrader_Data.MarketTicksDb.v20;Trusted_Connection=True;");
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                var tr = modelBuilder.Entity<TestRecord>()
    .HasMany(c => c.Tests).WithOne().HasPrincipalKey(p => p.Id);
    
            }
        }
        
        
        public class TestRecord
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            public string SomeK1 { get; set; }
    
            public string SomeK2 { get; set; }
    
            [Required]
            public List<Test> Tests { get; set; }
        }
    
        public class Test
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            public long SomeK1 { get; set; }
    
            public int V1 { get; set; }
    
            public int V2 { get; set; }
        }
    
    }
