    private Dictionary<int, string> GetEnumDictionary<T>() where T : struct, IConvertible 
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an enumerated type");
        }
        IEnumerable<T> enumValues = Enum.GetValues(typeof(T)).Cast<T>();
        var enumDictionary = enumValues.ToDictionary(value => Convert.ToInt32(value), value => value.ToString());
        return enumDictionary;
    }
