    var employees = new List<Employee>();
    // Populate our list with two employees
    for(int I = 0; I < 2; I++)
    {
        firstName = GetValue("First Name");
        lastName = GetValue("Last Name");
        employeeID = GetValue("Employee ID");
        department = GetValue("Employee Department");
        salary = Convert.ToDecimal(GetValue("Salary"));
        employees.Add(new Employee(firstName, lastName, employeeID, salary, department));
    }
    // Display the employee information:
    var counter = 1;
    foreach(var employee in employees)
    {
        Console.WriteLine("Total increase in salary for employee {0} is {1}",
            counter++, employee);
    }
