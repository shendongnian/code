    public T Get<T>(string key)
    {
        if(reader.IsDbNull(reader.GetOrdinal(key)))
        {
           //IF YOU SPECIFICALLY WANT TO THROW AN ERROR IF A VALUE TYPE
           //if (typeof(T).IsValueType) 
           //{ throw new InvalidCastException(); }
           return default(T);
        }
        return reader.GetFieldValue<T>(reader.GetOrdinal(key));
    }
