    var newTable = new DataTable();
    var moveCols = dtRecord.Columns.Cast<DataColumn>().Take(10).Select(c => c.ColumnName).ToList();
    foreach (var c in moveCols)
        newTable.Columns.Add(c);
    foreach (var r in dtRecord.AsEnumerable()) {
        var newr = newTable.NewRow();
        foreach (var c in moveCols)
            newr[c] = r[c];
        newTable.Rows.Add(newr);
    }
