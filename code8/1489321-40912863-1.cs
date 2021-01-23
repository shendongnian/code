    var selectedColumns = new[] { 0, 1, 4, 5 };
    var foo = data.Select(row => row.Split(new[] { "," }, StringSplitOptions.None)
                                    .Where((value, columnIndex) => selectedColumns.Contains(columnIndex)))
                  .Select(row => row.Select((Value, ColumnIndex) => new { Value, ColumnIndex })
                                    .GroupBy(pair => pair.ColumnIndex / 2)
                                    .Select(group => $"Group{group.Key}({String.Join(";", group.Select(pair => pair.Value))})"));
    foreach (var row in foo)
    {
        foreach (var item in row)
        {
            Console.WriteLine(item);
        }
    }
