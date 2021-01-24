    string columns = string.Join(",", StdTable.Columns.Cast<DataColumn>().Select(c => string.Foramt("[{0}]", c.ColumnName)));
    columns = columns.Replace(",F1", "");
    string values = string.Join(",", StdTable.Columns.Cast<DataColumn>().Select(c => string.Format("@{0}", c.ColumnName.Replace(" ", "_"))));
    values = values.Replace(",@F1", "");
    
    
    cmd1.Parameters.AddWithValue("@" + col.ColumnName.Replace(" ", "_"), row[col]);
