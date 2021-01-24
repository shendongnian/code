    public ActionResult Create()
    {
       var vm=new EmployeeViewModel();
       vm.EmployeeSelections = manager.getEmployeeData()
                                      .Select(a => new EmployeeSelection() {
                                            Id = a.Id,
                                            Name = a.Name})
                                      .ToList();
       return View(vm);
    }
