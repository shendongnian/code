    var dup = empList
        .GroupBy(x => new { x.Name })
    
        // Employees with duplicate name
        .Select(group => new { Emps = group.Select(x => x)})
    
        // From duplicates select only those that have a department 
        .SelectMany(x => {
            var emps = x.Emps.Where(y => !string.IsNullOrWhiteSpace(y.Dept));
            var employeesWithDept = emps.GroupBy(g => g.Name );
    
    
            IEnumerable<Dept> a = 
            employeesWithDept.Select(g => new Dept { Employees = g.ToList(), Name = g.Key.ToString(), Count = g.Count()});
            return a;
        })
        .OrderByDescending(x => x.Count);
