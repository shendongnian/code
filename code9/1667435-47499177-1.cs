    var entitiesWithPriorityMap = entitiesWithPriority.ToDictionary(e => e.entityName, e => true);  
    var entitiesWithIssueMap = entitiesWithIssue.ToDictionary(e => e.entityName, e => true);
    
    var result = allEntities.Select(entityName => new Entity()
    {
        Name = entityName,
        HasPriority = entitiesWithPriorityMap.ContainsKey(entityName),
        HasIssue = entitiesWithIssueMap.ContainsKey(entityName)
    });
