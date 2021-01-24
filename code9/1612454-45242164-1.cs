    public class UserManagement {
        //Static property 
        private static List<User> _users;
        public static List<User> Users {
            get { 
                if (_users == null) {
                    _user = new List<User>();
                }
                return _users; 
            }
            set { }
        }
        //Static load method must be called before accessing Users 
        public static void LoadDBUsers() {
            using (SqlConnection connection = new SqlConnection(connetionString)) {
                connection.Open();
                string readString = "select * from Users";
                using (SqlCommand command = new SqlCommand(readString, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            String tempEmail = reader["Email"].ToString();
                            String tempName = reader["Name"].ToString();
                            User user = new User(tempEmail, tempName, 0, "unset", false, false, false, false, false, false, false, "", false, false, false, 0, 0));
                            users.Add(user);
                        }
                    }
                }
            }
        }
    }
