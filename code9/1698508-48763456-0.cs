    var employees = db.Employees.Select(x => new
    {
        Department = x.Department.Name,
        Name = x.Name,
        Salary = x.Salaries.OrderByDescending(y => y.Date).First().Amount
    }); 
