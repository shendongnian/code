    OleDbCommand cmd = new OleDbCommand(query, conn);
    OleDbDataReader reader = cmd.ExecuteReader();
    object[] fields = new object[reader.FieldCount];
    for (int i = 0; i < fields.Length; i++)
        dt.Columns.Add(new DataColumn(reader.GetName(i)));
    dt.Columns[0].DataType = typeof(string);
    dt.Columns[1].DataType = typeof(string);
    dt.Columns[2].DataType = typeof(int);
    while (reader.Read())
    {
        reader.GetValues(fields);
        dt.Rows.Add(fields);
    }
    reader.Close();
