    private IList<string> tags = new List<string>();
    public IEnumerable<string> Tags { get; }
    public MyClass()
    {
        Tags = new ReadOnlyCollection<string>(this.tags);
    }
