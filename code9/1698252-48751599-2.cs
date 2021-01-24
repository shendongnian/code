    public ActionResult Index()
    {
        // This could come from database.
        var model = new EmployeeViewModel
        {
            DepartmentViewModels = new List<DepartmentViewModel>
            {
                new DepartmentViewModel{ DepartmentCode = "ABC", DepartmentValue = 1},
                new DepartmentViewModel{ DepartmentCode = "DEF", DepartmentValue = 2},
                new DepartmentViewModel{ DepartmentCode = "GHI", DepartmentValue = 3},
            }
        };
        return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(EmployeeViewModel model)
    {
        return View(model);
    }
