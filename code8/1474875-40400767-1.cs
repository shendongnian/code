    public DataTable ExecDataTable(OleDbCommand cmd)
    {
        try
        {
            con.Open();
            if(cmd.Connection == null)
               cmd.Connection = con;
 
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dataTable);
            da.Dispose();
        }
        catch
        {
            throw;
        }
        finally 
        {
            con.Close();
        }
        return dataTable;
    }
