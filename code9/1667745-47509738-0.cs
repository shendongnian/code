    public MyClass(Type type)
    {
        if (!(typeof(IMyInterface).IsAssignableFrom(type)))
            throw new ArgumentException();
    
        this.Type = type;
    }
