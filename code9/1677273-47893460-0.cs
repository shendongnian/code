    static void Main(string[] args)
    {
        foreach (var item in GetStringNames<Group>())
        {
            Console.WriteLine(item);
        }
    }
    public static string GetStringValue(Enum value)
    {
        Type type = value.GetType();
        FieldInfo fieldInfo = type.GetField(value.ToString());
        StringValueAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
        string stringValue = null;
        if (attributes.Length > 0)
        {
            stringValue = attributes[0].Value;
        }
        return stringValue;
    }
    public static IEnumerable<string> GetStringNames<T>()
    {
        var type = typeof(T);
        if (type.IsEnum == false)
        {
            throw new ArgumentException("T must be an Enum type");
        }
        var values = type.GetEnumValues();
        foreach (var item in values)
        {
            yield return GetStringValue((Enum)item);
        }
    }
