    public static T[] Select<T>(IMongoCollection<T> collection,  
                                 Expression<Func<T, bool>> condition)
    {
        if (typeof(T) == typeof(Person))
        {
             return collection.AsQueryable().Where(condition).ToArray();
        }
        return null;
    }
