    public override SqlConnection OpenConnection()
    {
         var conn = new SqlConnection(Connection.GetConnection))
         conn.Open();
         return conn;
    }
