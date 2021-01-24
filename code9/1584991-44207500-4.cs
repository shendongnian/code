    public object GetList(string tableEntity)
    {
        Type tableEntity = Type.GetType("TestProject." + typeName + ", TestProject");
    
        var dbObject = (System.Collections.IEnumerable)
                            typeof(DbContext).GetMethod("Set", Type.EmptyTypes)
                            .MakeGenericMethod(tableEntity)
                            .Invoke(databaseContext, null);
    
        return dbObject.AsQueryable();            
    }
