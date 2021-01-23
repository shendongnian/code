    var tables = new List<DataTable>();
    foreach (var file in files)
    {
                // ....
                tables.Add(reader.AsDataSet().Tables[0]);
                // ...
    }
    DataTable mergedTables = tables.MergeAll("PimaryKeyColumnName");
