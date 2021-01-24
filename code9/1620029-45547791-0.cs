    protected List<Activity> _entries;
    public List<Activity> Entries
    {
        //don't create a new list in getter!
        //get { return _entries.OrderBy(e => e.StartTime).ToList(); }
        get { return _entries; }
        set { _entries = value; }
    }
