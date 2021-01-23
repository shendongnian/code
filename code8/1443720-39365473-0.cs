	var departmentEmployeeCount = database.Employees
		.GroupBy(x => x.DepartmentId)
		.Select(x => new { DepartmentId = x.Key, Count = x.Count() })
		.ToArray();
	var query = (from Department dept in database.Department
				 join emp in database.Employees on dept.EmployeeId equals emp.EmployeeId
				 where dept.IOfficeId == officeId
				 select new {
					emp.Name,
					dept.EmployeeId,
					dept.Name,
					dept.DepartmentId
				 }
				)
				.AsEnumerable()
				.Select(x => new EmployeeData {
					FullName = x.Name,
					EmployeeId = x.EmployeeId,
					DepartmentName = x.Name,
					EmployeeCount = departmentEmployeeCount
                        .Where(z => z.DepartmentId == x.DepartmentId)
                        .Select(x => x.Count)
                        .FirstOrDefault()
					}
				);
