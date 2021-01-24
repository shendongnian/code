    var columns = tbl.Columns.Cast<DataColumn>().ToList();
    var enumerableRowCollection = tbl.AsEnumerable();
    var results = enumerableRowCollection
        .Select((row, index) =>
        {
            var column = columns.FirstOrDefault(col => row[col].ToString() == "PEPSI");
            return new
            {
                Column = column,
                ColumnIndex = column != null ? columns.IndexOf(column) : -1,
                Row = row,
                RowIndex = index
            };
        })
        .Where(x => x.Column != null)
        .ToList();
    for (var i = 0; i < results.Count(); i++)
    {
        var result = results[i];
        Console.WriteLine($"Result {i}");
        Console.WriteLine($"RowIndex: {result.RowIndex}");
        Console.WriteLine($"ColumnIndex: {result.ColumnIndex}");
    }
