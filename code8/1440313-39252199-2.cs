    public class UsersContext {
        string connectionstring = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString.ToString();
        public User GetUserById(int UserId) {
            using (var connection = new MySqlConnection(connectionstring)) {
                var sqlCmd = new MySqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from User where id='" + UserId + "' ";
                sqlCmd.Connection = connection;
                connection.Open();
                using (var reader = sqlCmd.ExecuteReader()) {
                    var user = new User();
                    while (reader.Read()) {
                        user.FirstName = (Convert.IsDBNull(reader["FirstName"]) ? "" : Convert.ToString(reader["FirstName"]));
                    }
                    return user;
                }
            }
        }
    }
