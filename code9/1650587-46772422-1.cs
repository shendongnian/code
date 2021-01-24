    do {
        var employeeDetails = new Employee
        {
            FirstName = GetName("Enter firstname and press enter."),
            LastName = GetName("Enter firstname and press enter."),
        };
        employeeList.Add(employeeDetails);
        Console.WriteLine("Do You want to continue?");
        strChoice = Console.ReadLine().ToLower();
    } while (strChoice == "yes");
