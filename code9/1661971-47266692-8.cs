    public class EmployeeController
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController()
        {
            string connString = ConfigurationManager
                                    .ConnectionStrings["DefaultConnection"]
                                    .ConnectionString;
    
            _employeeRepository = new EmployeeRepository(connString);
        }
    
        [ActionName("EMPID")] //why does this say EMPID?
        public IEnumerable<Employee> Get()
        {            
            List<Employee> employees = _employeeRepository.GetAllEmployees();
            return employees;      
        }
    }
