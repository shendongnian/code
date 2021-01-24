    List<Employee> employees = ... 
    IEnumerable<DateTime> leaveDates = 
        employees.Where(e=>e.Name = "Thomas")
                 .SelectMany(e =>
                    Enumerable.Range(0, e.EndDate.Subtract(e.StartDate).Days + 1)
                              .Select(d => e.StartDate.AddDays(d)));
