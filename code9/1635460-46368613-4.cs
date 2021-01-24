    private DataTable _myDataTable;
    public DataTable MyDataTable
    {
        get { return _myDataTable; }
        set { SetProperty(ref _myDataTable, value); }
    }
    public void FillMyDataTable()
    {
        using (var conn = new SqlConnection("MyConnectionString"))
        using (var cmd = new SqlCommand("MyStoredProcedure", conn) { CommandType = System.Data.CommandType.StoredProcedure })
        {
            cmd.Parameters.AddWithValue("@d1", startDate);
            cmd.Parameters.AddWithValue("@d2", endDate);
    
            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            MyDataTable = ds.Tables[0];
        }       
    }
