    var result = string
        .Join("|", mainList)
        .Replace("Reset", "|@|Reset")
        .Split(new [] { "|@|" }, StringSplitOptions.RemoveEmptyEntries)
        .Select(c => c.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
        .ToList();
