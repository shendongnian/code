    [NotMapped]
    public IEnumerable<Activity> OrderedEntries
    {
        get { return _entries.OrderBy(e => e.StartTime); }
    }
