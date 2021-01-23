    public List<EmployeeBasicInfo> getProgramNames()
    {
        return  db.tbl_Employee.Where(c => c.EmpName == "sam")
                  .Select(x=> new EmployeeBasicInfo { Id=x.Id, FirstName = x.EmpName })
                  .ToList();
    }
