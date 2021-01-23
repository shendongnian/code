    var parents = ParentsSelector(10);
    var query = dbContext.MyTable
        .AsExpandable()
        .Where(x => x.Id == myId)
        .Select(x => new
        {
            Parents = parents.Invoke(x)
        });
