    string property = "BaseSalary";
    var parameter = Expression.Parameter(typeof(Employee));
    var propAccess = Expression.PropertyOrField(parameter, property);
    var expression = (Expression<Func<Employee, int?>>)Expression.Lambda(propAccess, parameter);
    var result = db.Employees
        .GroupBy(x => x.Region)
        .SelectWithReplace((g, willReplace) => new
        {
            Region = g.Key,
            Avg = g.Average(willReplace)
        }, expression);
