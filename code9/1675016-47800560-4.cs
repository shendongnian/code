    public EmployeesData Where(Func<Employee, bool> predicate)
    {
        return new EmployeesData
        {
            EmployeeSomethingAs = EmployeeSomethingAs.Where((Func<EmployeeSomethingA, bool>)predicate).ToList(),
            EmployeeSomethingBs = EmployeeSomethingBs.Where((Func<EmployeeSomethingB, bool>)predicate).ToList(),
            EmployeeSomethingCs = EmployeeSomethingCs.Where((Func<EmployeeSomethingC, bool>)predicate).ToList()
        };
    }
    var newEmployeesData = employeesData.Where(x => x.EmployeeID == 1);
