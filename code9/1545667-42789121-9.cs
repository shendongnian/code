    var columnsNames = new[] { "SomeNullableInt32", "SomeNonNullableDateTimeColumn" };
    // One for each column!
    var formatters = new Func<object, string>[]
    {
        x => x != null ? x.ToString() : null,
        x => ((DateTime)x).ToShortDateString()
    };
    var result = ctx.MyTable.Take(100).SimpleSelect(columnsNames).ToObjectArray();
    foreach (var row in result)
    {
        var stringRow = new string[row.Length];
        for (int i = 0; i < row.Length; i++)
        {
            stringRow[i] = formatters[i](row[i]);
        }
        Console.WriteLine(string.Join(", ", stringRow));
    }
