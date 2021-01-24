    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    
    namespace ConsoleApp6
    {
        public class Part
        {
            public int Id { get; set; }
            public string PartNumber { get; set; }
            public string Colour { get; set; }
            public int Height { get; set; }
    
            public virtual ICollection<Interchange> Interchanges { get; } = new HashSet<Interchange>();
    
        }
    
        public class Interchange
        {
            [Key]
            [Column(Order =1 )]
            public int FromPartId { get; set; }
    
            [Key]
            [Column(Order = 2)]
            public int ToPartId { get; set; }
    
            public virtual Part FromPart { get; set; }
            public virtual Part ToPart { get; set; }
        }
     
    
        
        class Db : DbContext
        {
    
            public DbSet<Part> Parts { get; set; }
            public DbSet<Interchange> Interchanges { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Part>()
                            .HasMany(p => p.Interchanges)
                            .WithRequired()
                            .HasForeignKey(i => i.FromPartId)
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
                    db.Database.Log = a => Console.WriteLine(a);
    
                    var A = db.Parts.Create();
                    A.PartNumber = "A";
    
                    var B = db.Parts.Create();
                    B.PartNumber = "B";
    
                    A.Interchanges.Add(new Interchange() {  FromPart = A, ToPart = B });
                    B.Interchanges.Add(new Interchange() { FromPart = B, ToPart = A });
    
                    db.Parts.Add(A);
                    db.Parts.Add(B);
    
                    db.SaveChanges();
                }
    
                using (var db = new Db())
                {
                    db.Configuration.LazyLoadingEnabled = true;
                    db.Configuration.ProxyCreationEnabled = true;
    
                    var A = db.Parts.Where(p => p.PartNumber == "A").Single();
    
                    Console.WriteLine($"Part {A.PartNumber} has {A.Interchanges.Count()} Interchanges");
    
                    Console.WriteLine($"Part {A.PartNumber} is interchangable with {A.Interchanges.First().ToPart.PartNumber}");
                }
                    Console.ReadKey();
            }
        }
    }
