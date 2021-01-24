    OleDbConnection conn = new OleDbConnection(connectionString);
    conn.Open();
    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    String[] sheetNames = new String[dt.Rows.Count];
    int i = 0;
    foreach (DataRow row in dt.Rows)
    {
       sheetNames[i] = row["TABLE_NAME"].ToString();
       i++;
    }
