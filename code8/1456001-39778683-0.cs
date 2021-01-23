    using System.Data.Entity;
    
    public async Task<ObservableCollection<EmployeeViewModel>> 
        SearchEmployeesAsync(string selectedColumn, string searchValue)
    {
        var parameter = Expression.Parameter(typeof(T), "e");
        Expression left = Expression.PropertyOrField(parameter, selectedColumn);
        object value = searchValue;
        if (selectedColumn == "employeeId")
        {
            var employeeId = -1;
            int.TryParse(searchValue, out employeeId);
            value = employeeId;
        }
        else
        {
            // case insensitive
            left = Expression.Call(left, "ToLower", Type.EmptyTypes);
            value = searchValue.ToLower();
        }
        var comparison = Expression.Lambda<Func<T, bool>>(
            Expression.Equal(left, Expression.Constant(value)),
            parameter);
       
        using (var context = new MyEntities())
        {
            var query = context.Employees
                .Where(comparison)
                .Select(e => new EmployeeViewModel
                {
                    // Populate view model from entity object here
                });
            var result = await query.ToListAsync();
            return new ObservableCollection<EmployeeViewModel>(result);
        }
    }
