    while(reader.Read())
    {
        employee= new employee();
        employee.Id= reader(0).GetInt32(0);
        employee.Name= reader(1).GetString(1);
        ...
        employee.EmployeeType=(EmployeeType)reader(4);
        
        if(employee.EmployeeType== EmployeeType.FullTimeEmployee)
        {
            //Do extra work for this type of employee
            ...
            return employee;
        }
    }
