    public ActionResult Index()
    {
        var vm = new List<EmployeeViewModel>();
        foreach (var employee in db.Employees)
        {
            vm.Add(new EmployeeViewModel
            {
                FirstName = employee.First_Name,
                LastName = employee.Last_Name,
                Email = employee.Email
            });
        }
        return View(vm);
    }
