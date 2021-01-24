    var source = "/jame/ng2ih4cj3ekk8/haki/g8o7o3";
    var results = source.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        .Select ((value, index) => new {value, index})
        .GroupBy(item => item.index / 2, item => item.value);
    foreach (var result in results)
    {
        var items = Regex.Replace(result.Last(), @"\d", match =>
        {
            return "," + match.Value + Environment.NewLine;
        });
        foreach (var item in items.Split(Environment.NewLine.ToCharArray(),
                                         StringSplitOptions.RemoveEmptyEntries))
            Console.WriteLine(result.First() + "," + item);
    }
