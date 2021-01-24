    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    
    namespace ConsoleApp6
    {
    
    
        [Table("Customers")]
        public class Customer
        {
            public int CustomerID { get; set; }
    
            public string Name { get; set; }
    
            public bool ShowRunningTotal { get; set; }
    
            public ICollection<SalesOrders> Orders { get; } = new HashSet<SalesOrders>();
        }
    
        public class SalesOrders
        {
            public int Id { get; set; }
            public float Amount { get; set; }
    
            public DateTime SaleDate { get; set; }
    
            public int CustomerId { get; set; }
            virtual public Customer Customer { get; set; }
        }
        class Db : DbContext
        {
    
            public DbSet<Customer> Customers { get; set; }
    
            public DbSet<SalesOrders> SalesOrders { get; set; }
        }
        class Program
        {
            static void Main()
            {
    
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
    
                using (var db = new Db())
                {
                    var q = from c in db.Customers
                            select new
                            {
                                c.CustomerID,
                                LastSale = c.Orders
                                            .Where(o => c.ShowRunningTotal)
                                            .OrderByDescending(o => o.SaleDate)
                                            .FirstOrDefault()
                            };
    
                    Console.WriteLine(q.ToString());
                }
    
                Console.ReadKey();
            }
    
    
        }
    }
