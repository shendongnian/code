    public CurrentUser GetCurrentUser(string currentUserName) {
            string connectionstring = "MY_CONNECTION_STRING";
            string sql = String.Format("select users.name 'Username', roles.name 'Role' from sys.database_principals users inner join sys.database_role_members memberof on users.principal_id = memberof.member_principal_id inner join sys.database_principals roles ON memberof.role_principal_id = roles.principal_id and roles.type = 'R' where users.name = '[{0}]'", currentUserName);
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            CurrentUser currentUser = new CurrentUser();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read()) {
                currentUser.Role = rdr["Role"].ToString();
                currentUser.Username = currentUserName;
                rdr.Close();
            }
            conn.Close();
           return currentUser;
        }
    public class CurrentUser
    {
        public string Username {get;set;}
        public string Role {get;set;}
     }
