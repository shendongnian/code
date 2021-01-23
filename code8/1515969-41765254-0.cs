    public string ExecuteScalar(SqlCommand query)
    {
        try 
        {
            DB.EConnection();
            query.Connection = DB.conn;
            string ret = query.ExecuteScalar().ToString();
            return ret;
        }
        finally 
        {
            if(DB.conn.State == ConnectionState.Open)
                DB.conn.Close();
        }
    }
