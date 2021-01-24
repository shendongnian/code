    private void loadExistingNavigationProperties<TEntity>(TEntity entityToInsert) where TEntity : class
    {
        Type tEntity = typeof(TEntity);
        var properties = tEntity.GetProperties().Except(tEntity.GetProperties().Where(x => x.Name.Contains("id")));
        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType.FullName.Contains("MyNamespace"))
            {
                object val = findNavigationProperty(property.GetValue(entityToInsert), tEntity);
                property.SetValue(entityToInsert, val);
            }
        }
    }
    
    private object findNavigationProperty(object navigationPropertyValue, Type tEntity)
    {
        DbSet navigationProperties = GetAllEntries(tEntity);
        foreach (var entity in navigationProperties)
        {
            // You may get a type issue.
            // If so: cast to the correct type or change "propertiesAreEqual".
            if (propertiesAreEqual(entity, navigationPropertyValue))
            {
                return entity;
            }
        }
        return navigationPropertyValue;
    }
    
    public DbSet GetAllEntries(Type tEntity)
    {
        using (var dbContext = new InventarDBEntities(MainWindow.connectionName))
        {
            return GetAllEntries(dbContext, tEntity);
        }
    }
    
    public DbSet GetAllEntries(InventarDBEntities dbContext, Type tEntity)
    {
        return dbContext.Set(tEntity);
    }
