    var table = new DataTable();
    table.Columns.Add("foo").Caption = "bar";
    var schema = table.CreateDataReader().GetSchemaTable();
    foreach(DataRow row in schema.Rows)
    {
        foreach(DataColumn col in schema.Columns)
        {
            Console.WriteLine($"{col.ColumnName}={row[col]}");
        }
        Console.WriteLine();
    }
