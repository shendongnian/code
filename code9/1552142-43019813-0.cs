     var employees = new List<Employee>();
    
     employees.Add(new Employee("1", " Ali","",1000));
     employees.Add(new Employee("2", "Billy","",1001));
    
     var xml = new XElement("root");
     var employeesElement = new XElement("Employees");
     
    
     foreach (var employee in employees)
      {
        employeesElement.Add(new XElement("employee", employee.Name));
      };
      xml.Add(employeesElement);
