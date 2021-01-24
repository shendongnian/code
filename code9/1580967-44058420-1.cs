    using (DatabaseEntities entities = new DatabaseEntities())
    {
        entities.Configuration.LazyLoadingEnabled = false;
        return entities.Aliases.FirstOrDefault(a => a.ID == id);
    }
