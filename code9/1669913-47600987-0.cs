    private static IEnumerable<IProperty> FindPropagatingProperties(InternalEntityEntry entry)    
        => entry.EntityType.GetProperties().Where(    
            property => property.IsForeignKey()    
                        && property.ClrType.IsDefaultValue(entry[property]));
        
    private static IEnumerable<IProperty> FindGeneratingProperties(InternalEntityEntry entry)    
        => entry.EntityType.GetProperties().Where(    
            property => property.RequiresValueGenerator()    
                        && property.ClrType.IsDefaultValue(entry[property]));
