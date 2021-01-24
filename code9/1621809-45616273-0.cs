    private Dictionary<string, Color> colours = typeof(Colors)
        .GetRuntimeProperties()
        .Select(c => new
        {
            Color = (Color)c.GetValue(null),
            Name = string.Join(" ", splitCapital(c.Name))
        }).ToDictionary(x => x.Name, x => x.Color);
