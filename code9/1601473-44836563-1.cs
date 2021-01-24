    public class MyStudentSqlServerRepository
    {
        private readonly string _connectionString;
    
        public MyStudentSqlServerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            var students = new List<Student>();
    
            using(var connection = new SqlConnection(_connectionString))
            using(var command = new SqlCommand("select Id, Name, DepartmentId from students where DepartmentId = @DepartmentId", connection))
            {
                command.Parameters.Add(new SqlParameter("DepartmentId", SqlDbType.Int).Value = departmentId);
                connection.Open();
    
                using(var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var student = new Student();
                        student.Id = (int)reader["Id"];
                        student.Name = (string)reader["Name"];
                        student.DepartmentId = (int)reader["DepartmentId"];
                        students.Add(student);
                    }                
                }
            }
         
            return students;
        }        
    }
