    public T GetExample<T>() where T : IExample,class,new()
    {
       
        IExample value;
    
        if (!examples.TryGetValue(typeof(T), out value))
        {
            // Object doesn't exist. Create and add
            value = new T();
            examples.Add(typeof(T), value);
        }
    
        return (T)value;
    }
