      clsEmployees Employees = new clsEmployees();
      Employees.Add(new clsEmployee(3, "Fred"));
      Employees.Add(new clsEmployee(5, "Jane"));
      Employees.Add(new clsEmployee(2, "Bob"));
      Employees.Add(new clsEmployee(1, "Sarah"));
 
      var sortedList = Employees.OrderBy(t => t.Number);
      foreach (var employee in sortedList)
      {
          Console.WriteLine("{0}  {1}", Employee.Number, Employee.Name);
      }
      Console.ReadLine();
