    public void format(object nObject)
    {
        foreach (var row in nObject.GetType().GetProperties())
        {
            Debug.Log($"Key{row.Name}={row.GetValue(nObject)}");
        }
    }
