    internal static bool TryConvertToString(object value, Type type, out string s)
    {
        //...
        type = value as Type;
        if (type != null)
        {
            s = type.AssemblyQualifiedName;
            return true;
        }
        //...
    }
