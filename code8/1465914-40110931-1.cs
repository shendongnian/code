        ...
        rows.Add(row);
    }
    if (rows.Count == 0)
    {
        var row = new Dictionary<string, object>();
        foreach (DataColumn col in dt.Columns)
            row.Add(col.ColumnName, "");
        rows.Add(row);
    }
    return serializer.Serialize(rows);    
