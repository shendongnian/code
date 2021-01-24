    while(reader.Read())
    {
        employee= new employee();
        employee.Id= reader.GetInt32(0);
        employee.Name= reader.GetString(1);
        ...
        employee.EmployeeType=(EmployeeType)reader.GetInt32(4);
        
        if(employee.EmployeeType== EmployeeType.FullTimeEmployee)
        {
            //Do extra work for this type of employee
            ...
            return employee;
        }
    }
