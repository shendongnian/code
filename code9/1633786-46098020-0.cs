    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApp8
    {
    
        public partial class Student
        {
            public int Id { get; set; }
            public string name { get; set; }
        }
    
    
     
        public class Db : DbContext
        {
            public DbSet<Student> Students { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost;database=EfCoreTest;Integrated Security=true;MultipleActiveResultsets=false");
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
                    db.Database.EnsureCreated();
                    
                    Student student = new Student();
                    student.name = "test";
                    
                    db.Add(student);
                    db.SaveChanges();
    
                    int newID = student.Id;
                    Console.WriteLine($"NewID {newID}");
                }
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
        
                
            }
        }
    }
