    return _context.Employees.Select(e => new EmployeeDTO
    {
        LName = e.LName,
        FName = e.FName,
        Title = e.Title,
        EmployeeApplicationsDTO = e.EmployeeApplications.Select(ea => new EmployeeApplicationsDTO
        {
            Application = ea.Application
        }).ToList()
    }).ToList();
