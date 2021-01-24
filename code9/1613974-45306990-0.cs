    private List<TEntity> BuildEntitiesToDelete(IList<TEntity> newEntities, IList<TEntity> existingEntities) where TEntity : IEntityWithId
    {
        var missingEntities = new List<TEntity>();
    
        var entities = newEntities.Select(e => e.Id);
        var newEntityIds = new HashSet<int>(entities);
    
        foreach (var entity in existingEntities)
        {
            if (entities.Count() == 0)
            {
                missingEntities.Add(entity);
            }
            else
            {
                if (!newEntityIds.Contains(entity.Id))
                {
                    missingEntities.Add(entity);
                }
            }
        }
    
        return missingEntities;
    }
