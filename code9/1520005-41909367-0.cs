    private DataTable ReadExcelFile(string sheetName, string path)
    {
    using (OleDbConnection conn = new OleDbConnection())
    {
    DataTable dt = new DataTable();
    string Import_FileName = path;
    string fileExtension = Path.GetExtension(Import_FileName);
    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
    using (OleDbCommand comm = new OleDbCommand())
    {
        comm.CommandText = "Select * from [" + sheetName + "$]";
        comm.Connection = conn;
        using (OleDbDataAdapter da = new OleDbDataAdapter())
        {
            da.SelectCommand = comm;
            da.Fill(dt);
            return dt;
        }
    }
    }
