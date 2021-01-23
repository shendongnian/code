    public class MyClassDbContext: DbContext
    {
      public MyClassDbContext(string connString)
            : base(connString)
        {
        }
        public DbSet<MyClass> MyClasses { get; set; }
    }
    
    public class MyClassController : Controller
    {
        public MyClassDbContext myClassDbContext = new MyClassDbContext("Name Of ConnectionString");
        public ActionResult Index()
        {
            return View(myClassDbContext.MyClasses.ToList());
        }
    }
