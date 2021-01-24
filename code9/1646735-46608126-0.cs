    public static List<T> GetEnumValuesInDeclarationOrder<T>()
    {
        var t = typeof(T);
        // first type in this array is the data-type of the enum, int32 if not defined
        var members = t.GetFields();
        var result = new List<T>(members.Length - 1);
        foreach (FieldInfo mem in members.Skip(1))
            result.Add((T)mem.GetValue(null));
        return result;
    }
