    public class TestContext : DbContext
        {
            public DbSet<Test> Tests { get; set; }
            public DbSet<TestRecord> TestRecords { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Asmodat_FxTrader_Data.TestDb.v1;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                var tr = modelBuilder.Entity<TestRecord>();
                tr.HasMany(p => p.Tests).WithOne(x => x.TestRecord).HasForeignKey(p => p.TestRecordId);
            }
        }
    
        [Table("TestRecords")]
        public class TestRecord
        {
            public TestRecord()
            {
                this.Tests = new List<Test>();
            }
    
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int TestRecordId { get; set; }
    
            public string SomeK1 { get; set; }
    
            public string SomeK2 { get; set; }
    
            public virtual ICollection<Test> Tests { get; set; }
        }
    
        [Table("Tests")]
        public class Test
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int TestId { get; set; }
    
            public int TestRecordId { get; set; }
    
            public virtual TestRecord TestRecord { get; set; }
    
    
            public long VT { get; set; }
    
            public int V1 { get; set; }
    
            public int V2 { get; set; }
        }
