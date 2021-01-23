    public class EmployeeVM
    {
        SDBContext db = new SDBContext();
    
        public List<Employee> Employees {get;set;}
    
        public EmployeeVM()
        {
            this.Employees= db.Employees.ToList();
        }
    }
