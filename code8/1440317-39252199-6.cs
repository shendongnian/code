    public class UsersContext {
        string connectionstring = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString.ToString();
        public User GetUserById(int UserId) {
            using (var connection = new MySqlConnection(connectionstring)) {
                using (var command = new MySqlCommand()) {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * from User where id='@UserId'";
                    command.Connection = connection;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@UserId";
                    parameter.Value = UserId;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    using (var reader = command.ExecuteReader()) {
                        var user = new User();
                        while (reader.Read()) {
                            user.FirstName = (Convert.IsDBNull(reader["FirstName"]) ? "" : Convert.ToString(reader["FirstName"]));
                        }
                        return user;
                    }
                }
            }
        }
    }
