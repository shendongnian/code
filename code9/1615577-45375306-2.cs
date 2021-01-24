    public string GetNameFromNameProperty(dynamic obj)
    {
        try
        {
            return obj.Name;
        }
        catch (RuntimeBinderException)
        {
            throw new PropertyDoesntExistException();
        }
    }
