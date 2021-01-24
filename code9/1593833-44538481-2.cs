    List<List<double>> example = new List<List<double>>();
    while (!reader.EndOfStream)
    {
            example.AddRange(reader.ReadLine()
            .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(item => !string.Equals("NAN", item, StringComparison.OrdinalIgnoreCase))
            .Where(items => items.Any())
            .Select(items => items.Select(item => double.Parse(item.ToString())).ToList()).ToList());
    }
