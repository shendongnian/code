    static IEnumerable<Team> GetOrdered(IEnumerable<Team> teams)
    {
        var set = teams is HashSet<Team> ? teams as HashSet<Team> : new HashSet<Team>(teams);
        var current = teams.Where(t => t.Parent == null).First();
        while (set.Count > 1)
        {
            yield return current;
            set.Remove(current);
            current = set.Where(t => t.Parent == current).First();
        }
        yield return set.Single();
    }
