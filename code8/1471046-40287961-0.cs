    namespace ConsoleApp1
    {
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using Microsoft.EntityFrameworkCore;
    
        public class Foo
        {
            [Key]
            public int Id { get; set; }
    
            public string Name { get; set; }
        }
    
        public class Bar
        {
            [Key]
            public int Id { get; set; }
    
            public int FooId { get; set; }
    
            [ForeignKey("FooId")]
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
                modelBuilder.Entity<Bar>(t =>
                {
                    t.HasOne(x => x.Foo).WithMany().ForSqlServerHasConstraintName("MyFK");
                });
            }
        }
    }
