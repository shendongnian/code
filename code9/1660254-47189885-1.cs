    public EmployeeTypeVM
    {
      // Properties you want to expose and annotate
    }
        using (var db = new MyDbContext)
        {
          var emp = db.EmployeeTypes.FirstOrDefault();
          var vm = Mapper.Map<EmployeeTypeVM>(emp);
          return View(vm);  // <-- passing view model
        }
