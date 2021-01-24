    using (var dbContext = new MyDbContext(...))
    {
        var myDepartment = dbContext.Departments
            .Where(department => department.DepartmentId == DeptId)
            .SingleOrDefault();
        // I know there is at utmost one, because it is a primary key
        if (myDepartment == null) ShowDepartmentMissing(...);
        var employeesOfDepartment = myDepartment.Employees
            .Select(employee => new
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Benefits = employee.Benefits,
            });
