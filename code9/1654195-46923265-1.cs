    public IEnumerable<IGrouping<string, Foo>> GetFoo3(IEnumerable<Foo> foos)
    {
        return foos.GroupBy(f => f.X)
                   .Select(f => f.GroupBy(g => g.Y)
                                 .Aggregate((a, b) =>
                                        a.Count() > b.Count() ? a :
                                        a.Count() < b.Count() ? b :
                                        a.Max(m => m.Z) >= b.Max(m => m.Z) ? a : b
                                 ));
    }
