    public class MyContextDb
    {
      public DbSet<EmployeeType> EmployeeTypes { get; set; }
    }
    public class MyController
    {
      public ActionResult Index()
      {
        using (var db = new MyDbContext)
        {
          var emp = db.EmployeeTypes.FirstOrDefault();
          return View(emp);  // <-- passing EF entity as view model
        }
      }
    }
