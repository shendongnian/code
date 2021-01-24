    var repeated = str.GroupBy(s => s).Where(group => group.Any())
        .Select(group =>
        {
            var indices = Enumerable.Range(1, str.Count).Where(i => str[i-1] == group.Key).ToList();
            return string.Join(" - ", group.Select((s, i) => indices[i]));
        });
