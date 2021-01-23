	using (var context = new MyDbContext())
	{
		var result = (from Employee employee in employees
					  join catalog in context.InOrgCatalogs on new { Alias = employee.Alias, Active = true } equals
					  new { Alias = catalog.Alias, Active = catalog.Active }
					  into ps
					  from p in ps.DefaultIfEmpty()
					  select new Employee { EmployeeId = employee.EmployeeId,EmployeeName = employee.EmployeeName, Alias = employee.Alias, InOrg = !(p == null) }).ToList();
	}
