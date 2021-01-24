    public DataTable GetRandomQuestionByCateId(string id, int z)
    {
        var conn = new SqlConnection(connectionString);
        var cmd = new SqlCommand("GetRandomQuest", conn) ;
        cmd.CommandType = CommandType.StoredProcedure 
        cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = id;
        cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = z;
        conn.Open();
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        return dt;
    }
