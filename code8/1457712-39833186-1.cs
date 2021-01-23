    public void ExecuteData(string proc, SqlParameter[] param)
    {
        SqlCommand Cmd = new SqlCommand();
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.CommandText = proc;
        Cmd.Connection = Acces.Connection;
        if (param != null)
        {
            Cmd.Parameters.AddRange(param);
        }
        Cmd.ExecuteNonQuery();
    }
