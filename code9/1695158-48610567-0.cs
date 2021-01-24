    var currLevel = myList.Where(x => x.HierarchyLevel == 0);
    while (currLevel.Any())
    {
        // Note: Maybe faster if myList was converted to a lookup first
        //       for this part, but this won't be an option if this is
        //       Linq2Sql, EF, etc. unless you pull everything into memory.
        var nextLevel = myList.Where(x => currLevel.Select(c => c.EntityId)
                                                   .Contains(x.ParentEntityId));
        // Do something here with additional levels.
        var currLevel = nextLevel;
    }
