    foreach (var entity in entities)
    {
        foreach (string lang in LanguageList)
        {
            var newEntity = entity;
            newEntity.Language = lang;
            entities.Add(newEntity);
        }
    }
