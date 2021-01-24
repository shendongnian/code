    public ActionResult Index()
    {
        var model = 
            new IndexViewModel
            {
                Title = "PeopleBase Dashboard",
                Employees = GetEmployees()
            };
        return View(model);
    }
