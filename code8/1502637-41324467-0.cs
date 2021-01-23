    var topEmpPerDep = _context.Departments
        .Select(dep => new
        {
            Department = dep.Name,
            Employee = dep.Employees.OrderByDescending(e => e.Reports.Count)
               .FirstOrDefault().Name
        });
