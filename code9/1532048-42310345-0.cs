    public bool IsValidUser(string _username, string _password)
    {
        Connection connec = new Connection();
        connec.SqlQuery("select COUNT(*) from manager where UserName=@username AND Password=@password");
        connec.cmd.Parameters.AddWithValue("@username", _username);
        connec.cmd.Parameters.AddWithValue("@password", _password);
        
        int userCount = (int) sqlCommand.ExecuteScalar();
        con.Close();
        cmd.Dispose();
        return userCount != 0;
    }
