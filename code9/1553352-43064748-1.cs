    List<EmployeeInfo> lst = (
                        from e in _context.Employee
                        where Employeeids.Contains(e.Eid)
                        select new EmployeeInfo
                        {
                            EmployeeId = e.EmployeeId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            MiddleName = e.MiddleName
                        }).ToList();
    
        //Need to simplify this below code to set values
    SetSalaryDetails(lst.SingleOrDefault(a => a.EmployeeId == item.CreatedBy), item, "Created");
    
    if (item.UpdatedBy.HasValue)
    {
        SetSalaryDetails(lst.SingleOrDefault(a => a.EmployeeId == item.CreatedBy), item, "Updated");
    }
