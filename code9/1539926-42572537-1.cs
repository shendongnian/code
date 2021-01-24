    private void Create<T>(DbSet<T> entities) where T: ILanguageEntity
    {
        
        foreach (var entity in entities)
        {
            foreach (string lang in LanguageList)
            {
                var newEntity = entity;
                newEntity.Language = lang;
    
                entities.Add(newEntity);
    
            }
        }
    }
