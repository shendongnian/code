    public object GetList(string tableEntity)
    {
        Type tableEntity = Type.GetType("TestProject." + typeName + ", TestProject");
        return GetType ()
            .GetMethod ("GetListHelper")
            .MakeGenericMethod (tableEntity)
            .Invoke    (this) ;
    }
    public object GetListHelper<T> () where T : class
    {
        var dbObject = databaseContext.Set<T> (null) ;
        return dbObject.AsQueryable();            
    }
