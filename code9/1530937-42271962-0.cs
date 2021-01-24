    // This will check if there is an existing name in your database
    bool IsEmployeeExist = db.Employees.Any(e => e.Name.Equals(employee.Name));
    
    if(IsEmployeeExist){
      // Show Error Message
    } else {
      // Do insert...
    }
