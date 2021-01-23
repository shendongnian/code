    public List<T> GetObjects<T>() where T : class
    {
        return GetObjects(typeof(T)).Cast<T>();
    }
    
    public List GetObjects(Type type)
    {
        ...
    }
