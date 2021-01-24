    public class MyStudentSqlServerRepository
    {
        private readonly string _connectionString;
    
        public MyStudentSqlServerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {    
            using(var connection = new SqlConnection(_connectionString))
            {
                var students = connection.Query<Student>("select Id, Name, DepartmentId from students where DepartmentId = @DepartmentId", new { DepartmentId = departmentId}).AsList();
				return students;
            }           
        }        
    }
