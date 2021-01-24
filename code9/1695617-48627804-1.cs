    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    //using Microsoft.Samples.EFLogging;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlClient;
    
    namespace EFCore2Test
    {
    
    
        public class Person
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            [Column("YearsSinceBirth")]
            public int Age { get; set; }
    
            [Column(TypeName = "xml")]
            public string DataXML { get; set; }
        }
    
        public class Location
        {
            public string LocationId { get; set; }
        }
    
        public class Db : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<Location> Locations { get; set; }
                
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=EFCoreTest;Trusted_Connection=True;MultipleActiveResultSets=true");
                base.OnConfiguring(optionsBuilder);
            }
        }
    
    
    
    
        class Program
        {
    
    
            static void Main(string[] args)
            {
    
                using (var db = new Db())
                {
                    db.Database.EnsureDeleted();
                    //db.ConfigureLogging(s => Console.WriteLine(s));
                    db.Database.EnsureCreated();
    
                    var p = new Person()
                    {
                        Name = "joe",
                        Age = 2,
                        DataXML = "<Properties><Age>21</Age></Properties>"
                    };
                    db.People.Add(p);
                    db.SaveChanges();
                }
                using (var db = new Db())
                {
                    var people = db.People.FromSql("SELECT * FROM [People] WHERE [DataXML].value('(/Properties/Age)[1]', 'int') = 21").AsNoTracking().ToList() ;
    
                    Console.WriteLine(people.First().Age);
                    
                    Console.ReadLine();
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
