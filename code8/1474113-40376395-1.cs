    public ActionResult Index()
    {
    ESSEntities DB = new ESSEntities();
    List<EmployeeMdl> EmpList = DB.Employees.ToList();
    return View(EmpList);
    }
