    DataSet ds = new DataSet();
    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + openFile.FileName + ";" +
                "Extended Properties=Excel 8.0;");
    
    using(OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Plan1$]", conn))
    {
        da.Fill(ds);
    }
    foreach(DataRow dr in ds.Tables[0].Rows)
        dr[0] = dr[0].ToString().Trim(); // trim the value in the first column and save it back
    vGrade.DataSource = ds.Tables[0];
    
    conn.Close();
