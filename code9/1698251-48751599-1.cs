    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public IList<DepartmentViewModel> DepartmentViewModels { get; set; }
    }
    
    public class DepartmentViewModel
    {
        public string DepartmentCode { get; set; }
        public int? DepartmentValue { get; set; }
    }
