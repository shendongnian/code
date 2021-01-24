    public System.Data.DataTable GetSummaryData(string SQLStatement, 
        OleDbParameter[] parameters)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        if (conn.State == ConnectionState.Open)
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(SQLStatement, conn);
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            using (System.Data.OleDb.OleDbDataAdapter rsAdapter = new System.Data.OleDb.OleDbDataAdapter())
            {
                rsAdapter.SelectCommand = cmd;
                rsAdapter.Fill(dt);
            }
        }
        return dt;
    }
