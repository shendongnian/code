    public class StudentSqlServerRepository
    {
        private readonly string _connectionString;
    
        public StudentSqlServerRepository(string connectionString)
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
