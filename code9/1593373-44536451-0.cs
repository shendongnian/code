    public class MyDataContext : DbContext
    {
        public MyDataContext():base("DefaultConnection") { }
    
        public DbSet<Student> Students { get; set; }
    }
    
    public class Student
    {
        public int ID { get; set; }
    
        public string Name { get; set; }
    }
    
    public ActionResult Index()
    {
        MyDataContext context = new MyDataContext();
        context.Students.Add(new Student() { ID = 1, Name = "name1" });
        context.SaveChanges();
        return Content("Create data OK!");
    }
