    public ActionResult Index()
    {
        var vm = new List<EmployeeViewModel>();
        foreach (var employee in db.Employees)
        {
            vm.Add(new EmployeeViewModel
            {
                EmployeeId = employee.ID,
                FirstName = employee.First_Name,
                LastName = employee.Last_Name,
                Email = employee.Email
            });
        }
        return View(vm);
    }
