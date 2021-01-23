    public List<Employee> GetAll()
    {
        List<Employee> empList = new List<Employee>();
        try
        {
            empList.AddRange(repo.GetAll<Employee>().ToList());
        }
        catch (Exception ex)
        {
            DALUtils.ErrorRoutine(ex, "EmployeeDAO", "GetAll");
        }
        return empList;
    }
