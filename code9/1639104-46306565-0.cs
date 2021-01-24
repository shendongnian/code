    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace Ef6Test
    {
    
        public class Car
        {
            public int Id { get; set; }
            public string CarType { get; set; }
    
            [ForeignKey("CarType")]
            public CarPrice Price { get; set; }
    
        }
        public class Honda: Car
        {
            
        }
        public class Toyota : Car
        {
    
        }
        public class CarPrice
        {
            [Key]
            public string CarType { get; set; }
    
            public int Price { get; set; }
    
        }
        class Db : DbContext
        {
    
    
            public DbSet<Car> Cars { get; set; }
            public DbSet<CarPrice> Prices { get; set; }
            
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Car>().Map<Honda>(c => c.Requires("CarType").HasValue("Honda"));
                modelBuilder.Entity<Car>().Map<Toyota>(c => c.Requires("CarType").HasValue("Toyota"));
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
                    db.Database.Initialize(true);
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
