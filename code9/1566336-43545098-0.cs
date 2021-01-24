    public IList<Entity> SearchRange(string lower, string upper)
    {
        return _session.Query<Entity>()
            .Where(e => e.Name.CompareTo(lower) >= 0 and e.Name.CompareTo(upper) <= 0)
            .ToList();
    }
