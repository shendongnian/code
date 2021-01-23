    OleDbConnection Oledbconn = new OleDbConnection(excelConnString);
    Oledbconn.Open();
    OleDbCommand cmd = new OleDbCommand("select * from [" + sheetName + "]", Oledbconn);
    OleDbDataReader reader = cmd.ExecuteReader();
    SqlConnection conn = new SqlConnection(connectionString);
    conn.Open();
    SqlBulkCopy copy = new SqlBulkCopy(conn);
    copy.BulkCopyTimeout = 120000;
    copy.DestinationTableName = "MyTable";
    // presupposes the columns line up, as they do in your example
    for (int i = 0; i < reader.FieldCount; i++)
        copy.ColumnMappings.Add(reader.GetName(i), reader.GetName(i));
    copy.WriteToServer(reader);
    reader.Close();
    conn.Close();
    Oledbconn.Close();
