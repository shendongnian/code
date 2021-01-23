    IQueryable<Foo> query = context.Foos.AsQueryable();
    List<int> Ids = new List<int>();
    Ids.AddRange(new[] {3,2,1});
    bool first = true;
    foreach (int id in Ids)
    {
        if (first)
        {
            query = query.Where(_ => _.FooId == id);
            first = false;
        }
        else
        {
            query = query.Union(context.Foos.Where(_ => _.FooId == id));
        }
    }
    var results = query.ToList();
