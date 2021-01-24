    public List<string> GetColumnNames(Type tablename)
    {
        var names = tablename.GetProperties().Select(p => p.Name).ToArray();
        return names.ToList();
    }
