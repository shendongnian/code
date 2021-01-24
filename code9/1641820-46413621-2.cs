    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace EFCore2Test
    {
    
        public class Note
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
    
        public class Item
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
        }
        public class Part
        {
            public int Id { get; set; }
            public ICollection<Part> ChildParts { get; } = new HashSet<Part>();
    
            public ICollection<Note> Notes { get; } = new HashSet<Note>();
    
            public int? ItemId { get; set; }
            public Item Item { get; set; }
        }
    
        public class Db : DbContext
        {
            public DbSet<Part> Parts { get; set; }
            public DbSet<Item> Items { get; set; }
            public DbSet<Note> Notes { get; set; }
    
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
    
                base.OnModelCreating(modelBuilder);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=EfCoreTest;Trusted_Connection=True;MultipleActiveResultSets=true");
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
    
                    var item = new Item();
                    db.Items.Add(item);
    
                    var p = new Part();
                    p.Item = item;
    
                    for (int i = 0; i < 10; i++)
                    {
                        var cp = new Part();
                        p.ChildParts.Add(cp);
                        db.Parts.Add(cp);
    
                    }
    
                    for (int i = 0; i < 4; i++)
                    {
                        p.Notes.Add(new Note() { Value = "Note" });
                    }
    
                    db.Parts.Add(p);
    
                    db.SaveChanges();
                    partid = p.Id;
                }
    
    
                using (var db = new Db())
                {
                    Console.WriteLine("With Change Tracking");
    
                    var q = from p in db.Parts
                                        .Include(p => p.Notes)
                                        .Include(p => p.Item)
                            orderby p.Id == partid?0:1, p.Id
                            select p;
    
                    var parts = q.Take(5).ToList();
    
                    foreach (var p in parts)
                    {
                        Console.WriteLine($"Part {p.Id}, Child Parts {p.ChildParts.Count}");
    
                    }
                    Console.WriteLine();
                }
    
    
                using (var db = new Db())
                {
                    Console.WriteLine("Without Change Tracking");
    
                    var q = from p in db.Parts.AsNoTracking()
                                         .Include(p => p.Notes)
                                         .Include(p => p.Item)
                            orderby p.Id == partid ? 0 : 1, p.Id
                            select p;
    
                    var parts = q.Take(5).ToList();
    
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
