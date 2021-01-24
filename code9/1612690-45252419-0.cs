        var x = _context.Employees
            .Include("Department")
            .ToList()
            .GroupBy(e => e.DepartmentId)
            .Select(y => new MyViewModel
            {
                 Department = y.First().Department.Name,
                 count = y.Count()               
            }).ToList();
