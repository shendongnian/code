    public class TypeXDictionary<T> : Dictionary<string, TypeYDictionary<T>>
    {
    }
    public class TypeYDictionary<T> : Dictionary<string, T>
    {
    }
