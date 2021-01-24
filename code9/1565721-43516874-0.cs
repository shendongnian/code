    _db.cmd.CommandText = @"SELECT * FROM dbo.IncomingLog WHERE
                        [Date Received] LIKE @p1 OR
                        [Reference Number] LIKE @p1 OR
                        [Time Received] LIKE @p1 OR
                        [Title/Description] LIKE @p1 OR 
                        [Received Copies] LIKE @p1 OR
                        [Originating Office] LIKE @p1 OR
                        [Received Person] LIKE @p1 OR
                        [Filed Under] LIKE @p1 OR
                        [Encoded By] LIKE @p1"
     List<SqlParameter> prms = new List<SqlParameter>()
     {
        new SqlParameter("@p1", SqlDbType.NVarChar) {Value = keyIDLS.Text}
     };
     dt = _db.executeDT(prms);
    .....
    public DataTable executeDT(List<SqlParameter> prms = null)
    {
        cmd.Connection = con;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable datatable = new DataTable("DataTable");
        if(prms != null) 
            adapter.SelectCommand.Parameters.AddRange(prms.ToArray());
        adapter.Fill(datatable);
        return datatable;
    }
