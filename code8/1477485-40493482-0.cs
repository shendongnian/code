    public string GetNameIfExists(dynamic item)
    {
        if (item.GetType().GetProperty("Name") != null)
        {
            return item.Name;
        }
        return null;
    }
