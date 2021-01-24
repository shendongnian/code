	public ActionResult Index()
	{
		using(EmployeeContext employeeContext = new EmployeeContext())
		{
			Employee[] employees = employeeContext.Employees.ToArray(); // now it will return an array
			return View(employees); // pass employees to your view
		}
	}
