    public static string GetNavigationByForeignKey(this DbContext context, Type entityType, string fkPropertyName)
    {
        var objectContext = (context as IObjectContextAdapter).ObjectContext;
        var entityMetadata = objectContext.MetadataWorkspace
            .GetItems<EntityType>(DataSpace.CSpace)
            .FirstOrDefault(et => et.Name == entityType.Name);
        var navigationProperty = entityMetadata.NavigationProperties
            .FirstOrDefault(prop => prop.GetDependentProperties().Any(dep => dep.Name == fkPropertyName));
        return navigationProperty.Name;
    }
