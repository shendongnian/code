    public T Get<T>(string key)
    {
        if (typeof(T) == typeof(GenericIsAuthenticatedResponse) && key == "1234")
            return (T)GetGenericIsAuthenticatedResponse();
        return default(T);
    }
