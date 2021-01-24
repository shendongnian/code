    public object Get<T>(string key)
    {
        if (typeof(T) == typeof(GenericIsAuthenticatedResponse) && key == "1234")
            return GetGenericIsAuthenticatedResponse();
        return default(T);
    }
