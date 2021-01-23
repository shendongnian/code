    public async Task<ObservableCollection<EmployeeViewModel>> 
        SearchEmployeesAsync(string selectedColumn, string searchValue)
    {   
      using (var context = new MyEntities())
      {
        var query = context.Employees.AsQueryable();
        
        switch(selectedColumn)
        {
          case "employeeId":
            var employeeId = -1;
            int.TryParse(searchValue, out employeeId);
            query = query.Where(e=>e.employeeId == employeeId);
            break;
          case "lastName":
            query = query.Where(e=>e.lastName == searchValue);
            break;
          case "securityId":
            query = query.Where(e=>e.securityId == searchValue);
            break;
          }
          query = query.Select(e=> new EmployeeViewModel
                {
                    // Populate view model from entity object here
                });
            return await Task.Run(() => new ObservableCollection<EmployeeViewModel>(query));
        }
    }
