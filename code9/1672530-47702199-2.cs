    static IEnumerable<(string Id, string Type, int Value)>
        ParseData(string input)
    {
        var lines = input.Split(new[] { Environment.NewLine },
                                StringSplitOptions.RemoveEmptyEntries);
        var validLines = lines.Where(s => !s.StartsWith('!'));
        foreach (var line in validLines)
        {
            var fields = line.Split('\t');
            yield return ( fields[0],
                           fields[1],
                           int.Parse(fields[2]));
        }
    }
