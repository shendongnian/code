    public Guid Save(object obj)
    {
        Guid newId = Guid.NewGuid();
        try
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            {
                if (IsXmlElement(method))
                {
                    object value = property.GetValue(obj);
                    // ...
                }
            }
