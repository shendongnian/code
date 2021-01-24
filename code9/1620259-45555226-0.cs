    System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(fileName) + ";Extended Properties = \"Text;HDR=YES;FMT=TabDelimited\"");
    conn.Open();
    string sql = "SELECT * FROM [" + System.IO.Path.GetFileName(fileName) + "]";
    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
    System.Data.DataSet ds = new System.Data.DataSet("CSV File");
    adapter.Fill(ds);
    conn.Close();
    return ds.Tables[0];
