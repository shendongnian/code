    public class Employee_ViewModel 
    {
        public static EmployeeViewModel From(Employees item)
        {
            var employeeViewModel = new EmployeeViewModel();
            employeeViewModel.EmployeeId = item.EmployeeId;
            //[other parameter]
            employeeViewModel.DepartmentId = item.DepartmentId;
            employeeViewModel.OccupationId = item.OccupationId;
            return employeeViewModel;
        }
    
        public int EmployeeId { get; set; }
        //[other parameter]
        public string DepartmentName { get; set; }
        public string OccupationName { get; set; }
    }
    
    List<Employee_ViewModel> item = contex.Employees.Where(w => w.IsActive == true && w.IsVisible == true)
                                         .Include(i => i.Departments)
                                         .Include(i => i.Occupations)
                                         .Select(s => Employee_ViewModel.From(s)
                                         {
                                             OccupationName = s.Occupations.Name,
                                             DepartmentName = s.Departments.Name
                                         })
                                         .ToList();
