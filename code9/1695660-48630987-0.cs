    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    
    namespace Ef6Test
    {
    
        public class Color
        {
            public static Color Red = new Color() { Name = "Red", RGB = 0xFF0000 };
            public static Color Green = new Color() { Name = "Green", RGB = 0x00FF00 };
            public static Color Blue = new Color() { Name = "Blue", RGB = 0x0000FF };
            [Key]
            public string Name { get; set; }
            public int RGB { get; set; }
        }
    
        public class Car
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public string ColorName { get; set; }
            public Color Color { get; set; }
        }
    
        class Db : DbContext
        {
    
            public DbSet<Color> Colors { get; set; }
            public DbSet<Car> Cars { get; set; }
    
    
            public override int SaveChanges()
            {
                return SaveChanges(false);
            }
            public int SaveChanges(bool includeStatic = false)
            {
                if (!includeStatic)
                {
                    foreach (var e in ChangeTracker.Entries<Color>())
                    {
                        e.State = EntityState.Unchanged;
                    }
                }
                
                return base.SaveChanges();
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    
        class MyInitializer : DropCreateDatabaseAlways<Db>
        {
            protected override void Seed(Db context)
            {
                base.Seed(context);
                context.Colors.AddRange(new[] {Color.Red,Color.Green,Color.Blue });
                context.SaveChanges(true);
                
            }
        }
    
        class Program
        {    
            static void Main(string[] args)
            {    
                Database.SetInitializer(new MyInitializer());
    
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
                    db.Database.Initialize(true);
                }
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
    
                    var c = db.Cars.Create();
                    c.Color = Color.Red;
                    db.Cars.Add(c);
    
                    db.SaveChanges();
    
                }
    
                
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
