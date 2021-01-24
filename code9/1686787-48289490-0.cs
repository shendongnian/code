    var dataTable = new DataTable(tableName);
    
    for (int field = 0; field < dataReader.FieldCount; field++)
    {
        var column = new DataColumn(dataReader.GetName(field), dataReader.GetFieldType(field));
        dataTable.Columns.Add(column);
    }
