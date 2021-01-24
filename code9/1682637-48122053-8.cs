    var newTable = new DataTable();
    foreach (var c in moveCols)
        newTable.Columns.Add(c);
    foreach (var r in dtRecord.AsEnumerable())
        newTable.Rows.Add(moveCols.Select(c => r[c]).ToArray());
