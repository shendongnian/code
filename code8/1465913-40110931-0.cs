        ...
        rows.Add(row);
    }
    if (rows.Count == 0)
    {
        foreach (DataColumn col in dt.Columns)
            row.Add(col.ColumnName, "");
    }
    return serializer.Serialize(rows);    
