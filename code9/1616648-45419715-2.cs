    DataColumn[] columns = tbl.Columns.Cast<DataColumn>().ToArray();
    var enumerableRowCollection = tbl.AsEnumerable();
    var results = enumerableRowCollection
        .Select(x => new
        {
            Column = columns.FirstOrDefault(col => x[col].ToString() == "PEPSI"),
            Row = x
        })
        .Where(x => x.Column != null)
        .Select(x => new
        {
            ColumnIndex = columns.IndexOf(x.Column),
            RowIndex = tbl.Rows.IndexOf(x.Row)
        })
        .ToList();
    for (var i = 0; i < results.Count(); i++)
    {
        var result = results[i];
        Console.WriteLine($"Result {i}");
        Console.WriteLine($"RowIndex: {result.RowIndex}");
        Console.WriteLine($"ColumnIndex: {result.ColumnIndex}");
    }
