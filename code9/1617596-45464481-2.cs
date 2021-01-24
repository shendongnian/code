    var tasks = new[]
    {
        new Task { Id = 1, Title = "A", ParentId = null },
        new Task { Id = 2, Title = "B", ParentId = null },
        new Task { Id = 3, Title = "C", ParentId = 1 },
        new Task { Id = 4, Title = "D", ParentId = 2 },
    };
    var childrenByParentId = tasks.ToLookup(t => t.ParentId);
