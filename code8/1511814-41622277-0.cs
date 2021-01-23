    public Guid Save<T>(T obj)
    {
        Guid newId = Guid.NewGuid();
        try
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(typeof(T)))
            {
                if (IsXmlElement(method))
                {
                    Object value = property.GetValue(obj);
                    // ...
                }
            }
