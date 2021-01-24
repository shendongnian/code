    public class EmployeeRepository
    {
        public string _connectionString;
    
        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public List<Employee> GetAllEmployees()
        {
            string query = "select EMPLOYEE_ID, FIRST_NAME, SALARY from Employee";
    
            using (SqlConnection myConnection = new SqlConnection(_connectionString))
            {
                // Query is an extension method from Dapper
                List<Employee> employees = conn.Query<Employee>(query).AsList();
                return employees;
            }
        }
    }
    
    [ActionName("EMPID")]
    public IEnumerable<Employee> Get()
    {
        string connString = ConfigurationManager
                              .ConnectionStrings["DefaultConnection"]
                              .ConnectionString;
    
        EmployeeRepository employeeRepository = new EmployeeRepository(connString);
        List<Employee> employees = employeeRepository.GetAllEmployees();
        return employees;      
    }
    
    public class Employee
    {
        public int EmployeeId { get; set; }
    
        public string FirstName { get; set; }
    
        public int Salary { get; set; }
    }
