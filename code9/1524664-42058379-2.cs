    static IEnumerable<Team> GetOrdered(IEnumerable<Team> teams)
    {
        var set = teams as HashSet<Team> ?? new HashSet<Team>(teams);
        var current = teams.First(t => t.Parent == null);
        while (set.Count > 1)
        {
            yield return current;
            set.Remove(current);
            current = set.First(t => t.Parent == current);
        }
        yield return set.Single();
    }
