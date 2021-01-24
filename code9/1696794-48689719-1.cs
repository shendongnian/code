    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    
    namespace Ef6Test
    {
        public class Car
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Color { get; set; }
            public DateTime UpdateDate { get; set; }
    
        }
    
        class Db : DbContext
        {
    
            public void Update<T>(T entity, Dictionary<string, string> valuesToUpdate) where T : class
            {
                var entry = ChangeTracker.Entries<T>().Where(e => object.ReferenceEquals(e.Entity, entity)).Single();
                foreach (var name in valuesToUpdate.Keys)
                {
                    var pi = typeof(T).GetProperty(name);
                    pi.SetValue(entity, Convert.ChangeType(valuesToUpdate[pi.Name], pi.PropertyType));
                    entry.Property(pi.Name).IsModified = true;
                }
            }
    
            public DbSet<Car> Cars { get; set; }
    
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
            }
    
    
    
            class Program
            {
    
    
                static void Main(string[] args)
                {
    
                    Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
    
                    using (var db = new Db())
                    {
                        db.Database.Log = m => Console.WriteLine(m);
                        db.Database.Initialize(true);
                    }
                    int id;
                    using (var db = new Db())
                    {
                        db.Database.Log = m => Console.WriteLine(m);
    
                        var c = db.Cars.Create();
                        c.Color = 2;
                        c.UpdateDate = DateTime.Now;
    
                        db.Cars.Add(c);
    
                        db.SaveChanges();
                        id = c.Id;
    
                    }
    
                    using (var db = new Db())
                    {
                        db.Database.Log = m => Console.WriteLine(m);
    
                        var c = new Car() { Id = id };
                        var updates = new Dictionary<string, string>();
                        updates.Add(nameof(Car.Color), "3");
                        updates.Add(nameof(Car.UpdateDate), "2017-01-02");
                        db.Cars.Attach(c);
    
                        db.Update(c, updates);
                        db.SaveChanges();
    
                    }
    
                    Console.WriteLine("Hit any key to exit");
                    Console.ReadKey();
                }
            }
        }
    }
