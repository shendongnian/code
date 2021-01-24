    var results = entities.GroupBy(a => a.UserName(
        .Where(g => !g.Any(a => a.IsCorrect))
        .SelectMany(g => g.Select(a => a.Answer))
        .Distinct()
        .ToList();
