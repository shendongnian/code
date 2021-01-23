    namespace ConsoleApp1
    {
        using Microsoft.EntityFrameworkCore;
    
        public class Foo
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
        }
    
        public class Bar
        {
            public int Id { get; set; }
    
            public int FooId { get; set; }
    
            public virtual Foo Foo { get; set; }
        }
    
        public class MyDb : DbContext
        {
            public DbSet<Foo> Foos { get; }
    
            public DbSet<Bar> Bars { get; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=test; Trusted_Connection=True");
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Foo>(t =>
                {
                    t.HasKey(x => x.Id);
                });
    
                modelBuilder.Entity<Bar>(t =>
                {
                    t.HasKey(x => x.Id);
                    t.Property(x => x.FooId).HasColumnName("FooIdColumn");
                    t.HasOne(x => x.Foo).WithMany().HasForeignKey(x => x.FooId).HasConstraintName("MyFK");
                });
            }
        }
    }
