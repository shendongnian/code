    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Ef6Test
    {
    
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public string Class{ get; set; }
    
            public decimal GPA { get; set; }
        }
    
        class Db : DbContext
        {
            public DbSet<Student> Students { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                using (var db = new Db())
                {
                    var q = db.Students
                             .GroupBy(s => s.Class)
                             .SelectMany(g => g.OrderByDescending(s => s.GPA).Take(3));
    
                    Console.WriteLine(q.ToString());
    
                    Console.ReadKey();
                }
                
            }
        }
    }
