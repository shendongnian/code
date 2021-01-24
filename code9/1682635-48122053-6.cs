    var newTable = new DataTable();
    foreach (var c in moveCols)
        newTable.Columns.Add(c);
    foreach (var r in dtRecord.AsEnumerable()) {
        var newr = newTable.NewRow();
        foreach (var c in moveCols)
            newr[c] = r[c];
        newTable.Rows.Add(moveCols.Select(c => r[c]).ToArray());
    }
