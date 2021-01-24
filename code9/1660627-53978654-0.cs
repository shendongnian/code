    var newTable = new Table(srv.Databases["MyDatabase"], "MyTable");
    var c = new Column(newTable, "MyColumn");
    c.DataType = new DataType(SqlDataType.NVarCharMax);
    newTable.Columns.Add(c);
    newTable.Create();
