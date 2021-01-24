    Employee newEmployee = entity.Employee.Where(x => x.EmployeeID == 
      Emp.EmployeeID).Select(x => x).FirstOrDefault();
    if(newEmployee!=null)
    {          
      newEmployee.FirstName = Emp.FirstName;
      newEmployee.LastName = Emp.LastName;
      newEmployee.BirthDate = Emp.BirthDate;                
      entity.SaveChanges();
      result = true;
    }
