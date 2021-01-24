    string[] columnsNames = Fields.Select(x => x.Key).ToArray();
    
    string columns = string.Join(",", columnsNames);
    
    dynamic queryResult = query.Take(10).Select("new (" + columns + ")");
