    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
    
    
     
        public class Specification
        {
            public int SpecificationId { get; set; }
    
            public string Name { get; set; }
    
            public int? ParentSpecificationId { get; set; }
    
            public virtual Specification ParentSpecification { get; set; }
    
            public virtual ICollection<Specification> Children { get; } = new HashSet<Specification>();
        }
    
        public class Db : DbContext
        {
            public DbSet<Specification> Specifications { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Specification>()
                            .HasMany(s => s.Children)
                            .WithOptional(s => s.ParentSpecification)
                            .HasForeignKey(s => s.ParentSpecificationId)
                            .WillCascadeOnDelete(false);
    
                base.OnModelCreating(modelBuilder);
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
          
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
                
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
    
                    db.Database.Initialize(false);
    
                      
                    Console.ReadKey();
                }
            }
        }
    }
