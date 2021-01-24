    public string GetCommonPath(string[] paths)
    {
        if (paths == null || !paths.Any()) return string.Empty;
        var first = paths.OrderBy(x => x.Length).First();
        var common = first.Substring(0, Enumerable.Range(0, first.Length)
            .Reverse()
            .FirstOrDefault(x => paths.All(line => line.Length > x && line.StartsWith(first.Substring(0, x)))));
        var lastChar = common.LastIndexOf(@"\");
        if (lastChar > -1)
            common = common.Substring(0, lastChar);
        return common;
    }
