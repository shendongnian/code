    private bool IsAuthenticate(string username,string password) {
        string constring = "datasource=localhost;username=username;password=password";
        string Query = "SELECT Count(*) FROM hotel WHERE (UserLogin = @UserLogin) AND (UserPassword = @UserPassword)";
        int RecordsMatched;
        string UserLogin = username;
        string UserPassword = SomeHashFunction(password)
        using (SqlConnection conDataBase = new SqlConnection(constring)) {
            using (SqlCommand cmd = new SqlCommand(Query, conDataBase)) {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserLogin", UserLogin);
                cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
                try {
                    conDataBase.Open();
                    RecordsMatched = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex) {
                    RecordsMatched = -1;
                    Console.Write(ex);
                    // your error handling here
                }
                finally {
                    conDataBase.Close();
                    // your cleanup here
                }
            }
        }
        // Logic for RecordsMatched
        // -1: An error occurred
        //  0: UserLogin and/or UserPassword did not match
        //  1: Authenticated
        // 2+: You have multiple users with same credentials
        return (RecordsMatched == 1);
    }
