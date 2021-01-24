    var employees = new List<Employee>();
    // Populate our list with two employees
    for (int i = 0; i < 2; i++)
    {
        var firstName = GetValue("First Name");
        var lastName = GetValue("Last Name");
        var employeeID = GetValue("Employee ID");
        var department = GetValue("Employee Department");
        var salary = Convert.ToDecimal(GetValue("Salary"));
        employees.Add(new Employee(firstName, lastName, employeeID, salary, department));
    }
    // Display the employee information:
    var counter = 1;
    foreach (var employee in employees)
    {
        Console.WriteLine("Total increase in salary for employee {0} is {1}",
            counter++, employee);
    }
