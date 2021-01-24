    var filter = new Foo
    {
        ID = null,
        Description = null,
        Location = 1,
    };
    
    var data = new List<Foo>
    {
        new Foo { ID = 1, Description = "one", Location = 1 },
        new Foo { ID = 2, Description = "two", Location = 0 },
        new Foo { ID = 3, Description = "three", Location = 1 },
    };
    
    var query = data.AsEnumerable();
    if (filter.ID != null)
        query = query.Where(x => x.ID == filter.ID);
    if (filter.Description != null)
        query = query.Where(x => x.Description == filter.Description);
    if (filter.Location != null)
        query = query.Where(x => x.Location == filter.Location);
    var result = query.ToList();
