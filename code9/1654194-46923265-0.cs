    public IEnumerable<IGrouping<string, Foo>> GetFoo2(IEnumerable<Foo> foos)
    {
        return foos.GroupBy(f => f.X)
                   .Select(f => f.GroupBy(g => g.Y)
                                 .MaxBy2(g => g.Count(), g => g.Max(m => m.Z)));
    }
