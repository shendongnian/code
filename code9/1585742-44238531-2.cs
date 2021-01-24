    public ActionResult Index()
    {
        NorthwindEntities db=new NorthwindEntities();
        Employee emp = db.Employees.Find(1);
        return View(emp);
    } 
