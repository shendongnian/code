    public ActionResult Index()
    {
        ESSEntities DB = new ESSEntities();
        List<Employees> lstDBEmployees = DB.Employees.ToList();
         
    List<EmployeeMdl> EmpList = new List<EmployeeMdl>();
    foreach(var thisEmployee in lstDBEmployees )
    {
           EmpList.Add(new EmployeeMdl(){
               prop1 = thisEmployee.prop1,
               prop2 = thisEmployee.prop2
           });
    }
        return View(EmpList);
    }
