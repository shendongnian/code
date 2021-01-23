    static Dictionary<string, Dictionary<string, int>> GetAllEnums(params Type[] types)
    {
        return types
            .SelectMany(t => t.GetProperties())
            .Select(p => p.PropertyType)
            .Where(t => t.IsEnum)
            .Distinct()
            .ToDictionary(t => t.Name, t =>
                Enum.GetNames(t)
                    .Zip(Enum.GetValues(t).Cast<int>(), (Key, Value) => new { Key, Value })
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
    }
