    ((IObjectContextAdapter)dbContext).ObjectContext.ObjectMaterialized += (s, e) =>
    {
        var entity = e.Entity as IHaveServiceLocator;
        if (entity != null)
        {
            entity.ServiceLocator = structureMapServiceLocator;
        }
    }
