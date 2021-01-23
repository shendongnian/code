    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    
    namespace ParentChild
    {
        public class Customer
        {
            [Key]
            public int? Id { get; set; }
            public string Name { get; set; }
            public virtual List<Booking> Bookings { get; set; }
        }
    
        public class Booking
        {
            [Key]
            public int? Id { get; set; }
            public string Title { get; set; }
            public DateTime? BookingDate { get; set; }
            public int? CustomerId { get; set; }
            [ForeignKey("CustomerId")]
            public virtual Customer Customer { get; set; }
        }
    
        public class ParentChildDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            public ParentChildDbContext(String connectionString)
            {
                ConnectionString = connectionString;
            }
    
            public String ConnectionString { get; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
    
                base.OnConfiguring(optionsBuilder);
            }
    
            public DbSet<Customer> Customer { get; set; }
    
            public DbSet<Booking> Booking { get; set; }
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                var dbContext = new ParentChildDbContext("server=(local);database=ParentChild;integrated security=yes;");
    
                var data = dbContext.Customer.Include(p => p.Bookings).ToList();
    
                Console.WriteLine("Customer: {0}, Bookings: {1}", data.First().Name, data.First().Bookings.Count);
    
                Console.ReadKey();
            }
        }
    }
