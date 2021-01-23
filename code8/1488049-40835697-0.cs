    public List<T> GetObjects<T>() 
    {
        return GetObjects(typeof(T)) as List<T>;
    }
    
    public List GetObjects(Type type)
    {
        ...
    }
