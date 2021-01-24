    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    
    namespace Ef6Test
    {
    
    
        class User
        {
            public int UserId { get; set; }
    
            // every User has zero or more Products :
            public virtual ICollection<Product> Products { get; } = new HashSet<Product>();
    
        
    }
    
        class Product
        {
            public int ProductId { get; set; }
    
            // every Product belongs to zero or more Users:
            public virtual ICollection<User> Users { get; } = new HashSet<User>();
    
    
        }
    
        class Db : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Product> Products { get; set; }
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
    
                    var lstProductIds = new List<int>() { 1, 2, 3 };
    
                    var q = from p in db.Products
                            where lstProductIds.Contains(p.ProductId)
                            from u in p.Users
                            select new { p.ProductId, u.UserId };
    
                    var UserDetails = q.ToList();
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
