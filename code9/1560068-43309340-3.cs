    String[] excelSheets = new String[dt.Rows.Count];
    int t = 0;
    //get the list of excelSheetNames
    foreach (DataRow row in dt.Rows)
    {
        excelSheets[t] = row["TABLE_NAME"].ToString();
        t++;
    }                    
    string query = string.Format("Select * from [{0}]", excelSheets[0]);
    System.Data.DataSet ds = new System.Data.DataSet();
    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection))
    {
        dataAdapter.Fill(ds);
    }
    if (ds.Tables.Count > 0)
    {
        DataTable tb = ds.Tables[0];
        return tb;
    }   
