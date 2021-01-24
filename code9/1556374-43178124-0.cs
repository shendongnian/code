    codes =
        aCodes
            .AsEnumerable()
            .GroupBy(ac => new Tuple<byte, int>(dict[ac.Serial], ac.Level))
            .Select(ac => new KeyValuePair<byte, string[]>(ac.Key.Item1, ac.ToArray()))
            .ToArray();
