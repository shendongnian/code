    List<DataTable> tables = new List<DataTable>();
    if (Path.GetExtension(opener.FileName) == ".csv")
    {
        OleDbConnection conn = new OleDbConnection(string.Format(
            @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};" +
            "Extended Properties=\"Text;HDR=YES;FMT=Delimited\"",
            opener.FileName
        ));
        conn.Open();
        string sql = string.Format("select * from [{0}]", Path.GetFileName(opener.FileName));
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        tables.Add(dt);
        reader.Close();
    }
    else
    {
        FileStream streamer = new FileStream(opener.FileName, FileMode.Open);
        IExcelDataReader reader = null;
        if (Path.GetExtension(opener.FileName) == ".xls")
            reader = ExcelReaderFactory.CreateBinaryReader(streamer);
        else
            reader = ExcelReaderFactory.CreateOpenXmlReader(streamer);
        DataSet results = reader.AsDataSet();
        results.Tables[0].Rows[0].Delete();
        results.AcceptChanges();
        foreach (DataTable table in results.Tables)
            tables.Add(table);
    }
