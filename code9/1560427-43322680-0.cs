    public void CreateClassInstance<T>()
    {
        Type ReceiveClasstype = typeof(T);
        T newObject = (T)Activator.CreateInstance(typeof(T));
        //set the CollarId property of newObject:
        var property = ReceiveClasstype.GetProperty("CollarID ");
        property.SetValue(newObject, "collar id value...");
    }
