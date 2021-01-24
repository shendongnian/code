    public IQueryable<Employee> ActiveEmployees 
    {
        get
        {
            return EmployeeDbSet.Where(e => e.IsActive);
        }
    }
       
