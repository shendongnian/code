    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace EFCore2Test
    {
        public class Part
        {
            public int Id { get; set; }
            public ICollection<Part> ChildParts { get; } = new HashSet<Part>();
    
        }
       
        public class Db : DbContext
        {
            public DbSet<Part> Parts { get; set; }
    
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
  
                base.OnModelCreating(modelBuilder);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true");
                base.OnConfiguring(optionsBuilder);
            }
        }
    
    
    
    
        class Program
        {
    
           
            static void Main(string[] args)
            {
    
                int partid;
                using (var db = new Db())
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
    
                    var p = new Part();
    
                    for (int i = 0; i < 10; i++)
                    {
                        var cp = new Part();
                        p.ChildParts.Add(cp);
                        db.Parts.Add(cp);
    
                    }
    
                    db.Parts.Add(p);
    
                    db.SaveChanges();
                    partid = p.Id;
                }
    
    
                using (var db = new Db())
                {
                    Console.WriteLine("With Change Tracking");
                    var parts = db.Parts.Where(p => p.Id != partid).OrderBy(p => p.Id).Take(5).ToList();
                    parts.Add(db.Parts.Find(partid));
                     
                    foreach (var p in parts)
                    {
                        Console.WriteLine($"Part {p.Id}, Child Parts {p.ChildParts.Count}");
    
                    }
                    Console.WriteLine();
                }
    
    
                using (var db = new Db())
                {
                    Console.WriteLine("Without Change Tracking");
                    var parts = db.Parts.Where(p => p.Id != partid).OrderBy(p => p.Id).Take(5).ToList();
                    parts.Add(db.Parts.AsNoTracking().Single( p => p.Id == partid));
    
                    foreach (var p in parts)
                    {
                        Console.WriteLine($"Part {p.Id}, Child Parts {p.ChildParts.Count}");
    
                    }
                }
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
