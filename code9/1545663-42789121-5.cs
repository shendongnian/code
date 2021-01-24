    using (var ctx = new Model1())
    {
        var result = ctx.MyTable
            .Take(100)
            .SimpleSelect(new[] { "ID", "Col1", "Col2" })
            .ToObjectArray();
        foreach (var row in result)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }
