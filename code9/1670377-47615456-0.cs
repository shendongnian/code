    using(OracleConnection con = new OracleConnection(connectionString)
    using(OracleCommand cmd = new OracleCommand("ALTER USER myUserName ACCOUNT UNLOCK;", con)
    {
        con.Open();
        cmd.ExecuteNonQuery();
    }
