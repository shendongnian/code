    var EmployeeList= new POCOFromDatabase() // contains emp name, StartDate,EndDate
    List<SomeList> someList= new List<SomeList>(); // properties like String EmployeeName, List<Datetime> listofDates;
    
    
      foreach(var employee in Employeelist)
      {
        var tempDate =employee.StartDate;
        while((employee.EndDate - tempDate).TotalDays > 0)
            {
              //  store the date in someList.
              // logic to check, if the employee is already added in the list,
              // if yes add dates to the current list or else create a new list for him
            someList.listDateTime.Add(tempDate);
            tempDate.AddDays(1)
            }
      }
