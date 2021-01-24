    public MyClass(Object obj)
    {
        if (!Attribute.IsDefined(obj.GetType(), typeof(SerializableAttribute)))
            throw new ArgumentException("The object must have the Serializable attribute.","obj");
        // ...
    }
