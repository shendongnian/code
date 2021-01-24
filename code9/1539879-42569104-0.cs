    ((IObjectContextAdapter)dbContext).ObjectContext.ObjectMaterialized += (s, e) =>
    {
        var entity = e.Entity as IHaveServceLocator;
        if (entity != null)
        {
            entiry.ServceLocator = structureMapServiceLocator;
        }
    }
