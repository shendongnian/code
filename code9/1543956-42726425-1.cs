    var lastRevision = 2;
    var srcSet = new List<ChangeLogObject>();
                    
    // 1. & 2.
    var entityGroupsByEntityId = srcSet
        .Where(m => m.Id > lastRevision) // greater than last revision
        //.OrderByDescending(m => m.ChangeDate)
        .GroupBy(m => m.EntityId)
        .Select(group => new
        {
            EntityId = group.Key,
            ChangeCount = group.Count(),
            Changes = group.ToList().OrderByDescending(m => m.ChangeDate)
        });
    
    //  3.
    var entityGroupsWithNoDeleteAndCreate = entityGroupsByEntityId
        .Where(group => !(group.Changes.Any(m => m.ChangeType == ChangeType.Created) 
        && group.Changes.Any(m => m.ChangeType == ChangeType.Deleted))); // it doesn't contain both creates and deletes
    
    // 4. 
    var entityGroupsWithoutDeletedAndNoCreate = entityGroupsWithNoDeleteAndCreate
        .Where(group => !(group.Changes.Any(m => m.ChangeType == ChangeType.Deleted) 
        && (group.Changes.Count(m => m.ChangeType == ChangeType.Created) < 1))); // it doesn't contain a delete without a create
    
    // 5. 
    var entityGroupsWithUpdatedButNoCreated = entityGroupsWithoutDeletedAndNoCreate
        .Where(group => group.Changes.Any(m => m.ChangeType == ChangeType.Updated) 
        && !group.Changes.Any(m => m.ChangeType == ChangeType.Created)) // it updated but not created
        .Select(group => new ChangeLogObject
        {
            EntityId = group.EntityId,
            ChangeDate = group.Changes.First().ChangeDate,
            ChangeType = group.Changes.First().ChangeType // don't change the type
        });
    
    // 6.
    var entityGroupsWithCreatedAndUpdatedOnly = entityGroupsWithoutDeletedAndNoCreate
        .Where(group => group.Changes.Any(m => m.ChangeType == ChangeType.Created) 
        && group.Changes.Any(m => m.ChangeType == ChangeType.Updated)) // it contains both created and updated
        .Select(group => new ChangeLogObject
        {
            EntityId = group.EntityId,
            ChangeDate = group.Changes.First(m => m.ChangeType == ChangeType.Updated).ChangeDate, // bring back the first updated record
            ChangeType = ChangeType.Created // change the type to created
        });
    
    // Join the 2 sets of Updated and Created changes
    var finalResult = entityGroupsWithUpdatedButNoCreated.Union(entityGroupsWithCreatedAndUpdatedOnly).ToList();
