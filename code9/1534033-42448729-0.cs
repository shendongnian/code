    public static string GetRelationshipSchemaName<T>(string relationshipPropertyName) where T:Entity
    {
        return typeof (T).GetProperties()
            .FirstOrDefault(x => x.Name == relationshipPropertyName)
            .GetCustomAttributes()
            .OfType<RelationshipSchemaNameAttribute>()
            .FirstOrDefault()
            ?.SchemaName;            
    }
    
    public static Relationship GetRelationship<T>(string relationshipPropertyName) where T : Entity
    {
        return new Relationship(typeof(T).GetProperties()
            .FirstOrDefault(x => x.Name == relationshipPropertyName)
            .GetCustomAttributes()
            .OfType<RelationshipSchemaNameAttribute>()
            .FirstOrDefault()
            ?.SchemaName);
    }
