    protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
               
    
                var tr = modelBuilder.Entity<TestRecord>();
                    tr.HasKey(c => new { c.SomeK1, c.SomeK2 });
                tr.HasMany(c => c.Tests).WithOne().HasPrincipalKey(p => p.SomeK1);
                    tr.ToTable("Records");
           
    
                        var t = modelBuilder.Entity<Test>();
                    t.HasKey(c => c.SomeK1);
                t.Property(c => c.SomeK1).ValueGeneratedNever();
            }
