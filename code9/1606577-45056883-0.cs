    string sqlQuery="select * from Table where col1 = @param1 and col2 = @param2";
    var newQuery = a.Substring(0, a.IndexOf("where"));
    
    TCommand cmd = new TCommand();
    cmd.CommandText = newQuery;
    cmd.Connection = connection;
    
    using (var reader = cmd.ExecuteReader())
    {
        reader.Read();
    
        var columns = reader.GetSchemaTable().AsEnumerable()
                            .Select(col => col["ColumnName"].ToString())
                            .ToArray();
    
        return columns;
    }
