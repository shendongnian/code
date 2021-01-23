    public Guid Save<T>(T obj)
    {
        Guid newId = Guid.NewGuid();
        try
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(typeof(T)))
            {
                if (IsXmlElement(method))
                {
                    object value = property.GetValue(obj);
                    // ...
                }
            }
