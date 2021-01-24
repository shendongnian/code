    private IEnumerable<int> SortFunc(IEnumerable<int> data)
    {
        var ordered = 
            data.GroupBy(i => i)
                .OrderByDescending(group => group.Key)
                .Select(group => new
                {
                    Key = group.Key,
                    Duplicates = group.Skip(1)
                });
        foreach (var key in ordered.Select(group => group.Key))
        {
            yield return key;
        }
        foreach (var value in ordered.SelectMany(group => group.Duplicates))
        {
            yield return value;
        }
    }
