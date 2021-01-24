    // Assuming you have some way to get all employees
    List<Employee> allEmployees = SomeMethod.GetAllEmployees();
    // Assuming you have a department you want to find employees in
    Department hrDepartment = new Department { Name = "HumanResources" };
    // You can do something like this to get all employees in the HR department
    List<Employee> hrEmployees = allEmployees.Where(e => e.Department.Equals(hrDepartment));
