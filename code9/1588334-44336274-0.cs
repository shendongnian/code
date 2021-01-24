    public class MyContext : DbContext {
    
       public MyContext() : base("name=MyContextDB") {
          Database.SetInitializer<MyContext>(new UniDBInitializer<MyContext>());
       }
    
       public virtual DbSet<Course> Courses { get; set; }
       public virtual DbSet<Enrollment> Enrollments { get; set; }
       public virtual DbSet<Student> Students { get; set; }
    	
       private class UniDBInitializer<T> : DropCreateDatabaseAlways<MyContext> {
    
          protected override void Seed(MyContext context) {
    
             IList<Student> students = new List<Student>();
    			
             students.Add(new Student() {
                FirstMidName = "Andrew", 
                LastName = "Peters", 
                EnrollmentDate = DateTime.Parse(DateTime.Today.ToString()) 
             });
    
             students.Add(new Student() {
                FirstMidName = "Brice", 
                LastName = "Lambson", 
                EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
             });
    
             students.Add(new Student() {
                FirstMidName = "Rowan", 
                LastName = "Miller", 
                EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
             });
    
             foreach (Student student in students)
             context.Students.Add(student);
             // write to CSV
             WriteToCSV(Students);
             base.Seed(context);
          }
          private void WriteToCSV(Students students)
          {
            ...code to write to csv
          }
       }
    }
