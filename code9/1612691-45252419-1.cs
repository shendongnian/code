        var x = _context.Employees
            .Include("Department")
            .GroupBy(e => e.Department.Name)
            .Select(y=> new MyViewModel
            {
                Department = y.Key,
                count = y.Count()               
            }).ToList();
    
