    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp5
    {
        public class Order
        {
            public int Id { get; set; }
            public string Description { get; set; }
            internal ICollection<Purchase> Purchases { get; } = new HashSet<Purchase>();
            public Purchase Purchase { get { return Purchases.FirstOrDefault(); } }
        }
    
        public class Purchase
        {
            public int Id { get; set; }
            public string Description { get; set; }
    
            [Index(IsUnique = true)]
            public int? OrderId { get; set; }
    
            [ForeignKey("OrderId")]
            public virtual Order Order { get; set; }
        }
    
        public class Db : DbContext
        {
            public DbSet<Order> Orders { get; set; }
            public DbSet<Purchase> Purchases { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Order>().HasMany(o => o.Purchases).WithOptional(p => p.Order);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
                int OrderId;
                using (var db = new Db())
                {
              
                    var o = db.Orders.Create();
                    o.Description = "New Order";
    
                    var p = db.Purchases.Create();
                    p.Order = o;
                    p.Description = "New Purchase";
    
    
                    db.Orders.Add(o);
                    db.Purchases.Add(p);
                    db.SaveChanges();
                    OrderId = o.Id;
    
                }
                using (var db = new Db())
                {
                    var p = db.Purchases.Create();
                    p.OrderId = OrderId;
                    p.Description = "Another Purchase";
                    db.Purchases.Add(p);
                    db.SaveChanges(); //fails
    
                }
            }
        }
    }
