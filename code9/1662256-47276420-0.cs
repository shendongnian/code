    public static object GetFieldValue(this object input, string name)
    {
        return input
            .GetType()
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .ToList()
            .Where(f => f.Name == name)
            .Single()
            .GetValue(input);
    }
