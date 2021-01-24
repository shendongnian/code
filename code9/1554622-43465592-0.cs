    public T GetConfigModel<T>(string name) where T : new()
    {
        if (string.IsNullOrWhiteSpace(name))
            return default(T);
    
        try
        {
            return _configuration.GetValue<T>(name);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
