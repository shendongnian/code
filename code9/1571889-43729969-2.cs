    public YourEntity[] Search(string name = "", int? age = null, bool? isActive = null)
    {
        IQueryable<YourEntity> entities = dbContext.Set<YourEntity>();
        if (!string.IsNullOrWhiteSpace(name))
        {
            entities = entities.Where(x => x.Name.Contains(name));
        }
        if (age.HasValue)
        {
            entities = entities.Where(x => x.Age == age.Value);
        }
        if (isActive.HasValue)
        {
            entities = entities.Where(x => x.IsActive == isActive.Value);
        }
    
        return entities.ToArray();
    }
