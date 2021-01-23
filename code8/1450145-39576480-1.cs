    // Bogus query, we don't want any record, so add a always false condition
    OleDbCommand cmd = new OleDbCommand("SELECT * FROM aTable where 1=2", con);
    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    DataTable test = new DataTable();
    da.FillSchema(test, SchemaType.Source);
    for(int x = 0; x < test.Columns.Count; x++)
    {
        DataColumn dc = test.Columns[x];
        Console.WriteLine("ColName = " + dc.ColumnName + 
                          ", at index " + x +
                          " IsAutoIncrement:" + dc.AutoIncrement);
    }
