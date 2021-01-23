    // If you go for the AutoMapper approach, you need no constructor 
    // with parameters or factory method anymore!
    List<Employee_ViewModel> item = contex.Employees.Where(w => w.IsActive == true && w.IsVisible == true)
                                         .Include(i => i.Departments)
                                         .Include(i => i.Occupations)
                                         .Select(s => Mapper.Map<EmployeeViewModel(s))
                                         .ToList();
