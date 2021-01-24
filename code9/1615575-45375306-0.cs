    public string GetNameFromNameProperty(object obj)
    {
        var type = obj.GetType();
        return type.GetProperty("Name").GetValue(obj) as string;
    }
