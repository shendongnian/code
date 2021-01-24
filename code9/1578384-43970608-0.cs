    class Program
    {
        static void Main(string[] args)
        {
            using (SchoolContext context = new SchoolContext())
            {
                context.Students.Add(new Student { ID = 1, FirstMidName = "FMN", LastName = "LN", EnrollmentDate = DateTime.Now });
                context.SaveChanges();
            }
    
            Console.Write("Create database OK");
            Console.Read();
        }
    }
    
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
    
    public class SchoolContext : DbContext
    {
    
        public SchoolContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amor\Desktop\TestEF\CodeFirstSample\Database1.mdf;Integrated Security=True")
        {
        }
    
        public DbSet<Student> Students { get; set; }
    }
