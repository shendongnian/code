     public ActionResult Index()
     {
        MainDbContext db = new MainDbContext();
        var departments = (from c in db.Departments
                           select new Department
                           {
                              DepartmentID = c.Id,
                              Code = c.Code
                           }).ToList(); //Get department details
        return View(departments);
     }
