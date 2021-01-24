    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var AllEmployees = await _Context.Employee.ToListAsync();
  
        var model = new EmployeeViewModel();
        model.Employees = AllEmployees;
        return View(model);
    }
