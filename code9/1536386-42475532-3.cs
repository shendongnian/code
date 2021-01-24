    public interface IDbConnectionFactory {
        ///<summary>
        /// Creates a connection based on the given connection string.
        ///</summary>
        IDbConnection CreateConnection(string nameOrConnectionString);
    }
    public class SqlConnectionFactory : IDbConnectionFactory {
        public IDbConnection CreateConnection(string nameOrConnectionString) {
            return new SqlConnection(nameOrConnectionString);
        }
    }
    public static class DbExtension {
        public static IDbDataParameter AddParameterWithValue(this IDbCommand command, string parameterName, object value) { 
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            command.Parameters.Add(parameter);
            return parameter;
        }
        public static IDbCommand CreateCommand(this IDbConnection connection, string commandText) {
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            return command;
        }
    }
	
	public class EmployeeSqlRepository : IEmployeeRepository {
		private IDbConnectionFactory connectionFactory;
		public EmployeeSqlRepository(IDbConnectionFactory connectionFactory) {
			this.connectionFactory = connectionFactory;
		}
		public void Add(Employee model) {
			using (var connection = connectionFactory.CreateConnection("sqlconnection")) {
				using (var command = connection.CreateCommand("sp_insert")) {
					command.CommandType = CommandType.StoredProcedure;
					command.AddParameterWithValue("fname", model.FirstName);
					command.AddParameterWithValue("lname", model.LastName);
					command.AddParameterWithValue("age", model.Age);
					command.AddParameterWithValue("phoneno", model.phoneNumber);
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}
		public List<Employee> GetAll() {
			var employeeList = new List<Employee>();
			using (var connection = connectionFactory.CreateConnection("sqlconnection")) {
				using (var command = connection.CreateCommand("GetAllEmployees")) {
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (var reader = command.ExecuteReader()) {
						while (reader.Read()) {
							var employee = new Employee();
							employee.EmployeeId = int.Parse(reader["empID"].ToString());
							employee.FirstName = reader["fname"].ToString();
							employee.LastName = reader["lname"].ToString();
							employee.Age = int.Parse(reader["age"].ToString());
							employee.phoneNumber = int.Parse(reader["phone"].ToString());
							employee.SetRepository(this);
							employeeList.Add(employee);
						}
					}
				}
			}
			return employeeList;
		}
	}
