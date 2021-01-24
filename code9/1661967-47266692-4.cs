    using Dapper; //add this to your using statements
    public class EmployeeRepository
    {
        private readonly string _connectionString;
    
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
