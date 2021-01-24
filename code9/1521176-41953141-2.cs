    [HttpGet]
	public ActionResult Save()
	{
		var employee = new Employee();
		return View(employee);
	}
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Save(Empoyee employee)
	{
		if (!ModelState.IsValid)
		{
			//do whatever you want here
		}
		return View(employee);
	}
