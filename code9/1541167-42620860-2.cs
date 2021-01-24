    var allEmployeeLeaveList = new List<EmployeeLeave>();
   
      foreach(var employee in LeaveData)
      {
        var tempDate = employee.StartDate.valueOrDefault();
        while((employee.EndDate.valueOrDefault() - tempDate).TotalDays > 0)
            {
             if( allEmployeeLeaveList .Any(x=>x.empName == employee.Emp_Name ))
               {
                  allEmployeeLeaveList .Where(x=>x.empName == employee.Emp_Name    ).LeavesDate .Add(tempDate);
               }
           else
               {
            allEmployeeLeaveList.Add(new EmployeeLeave
                                         {
                                          empName  = employee.Emp_Name ,
                                          LeavesDate = new List<DateTime>  
                                                         {tempDate}         
                                          });
               }
            tempDate.AddDays(1)
            }
      }
