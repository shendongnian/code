    public class SchoolContext : DbContext
    {
    	public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    	{
    	}
    
    	public DbSet<Student> Students { get; set; }
    	public DbSet<Instructor> Instructors { get; set; }
    	public DbSet<Person> People { get; set; }
    
    	protected override void OnModelCreating(ModelBuilder b)
    	{
    		b.Entity<Student>().ToTable("Student");
    		b.Entity<Instructor>().ToTable("Instructor");
    		b.Entity<Person>().ToTable("Person");
    	}
    }
    
    public abstract class Person
    {
    	public int ID { get; set; }
    
    	public string LastName { get; set; }
    	public string FirstMidName { get; set; }
    }
    
    public class Instructor : Person
    {
    	public DateTime HireDate { get; set; }
    }
    
    public class Student : Person
    {
    	public DateTime EnrollmentDate { get; set; }
    }
