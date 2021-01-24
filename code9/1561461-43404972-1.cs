    public static string GetTypeName(this Type type)
    {
        if (type.IsArray)
        {
            return "array";
        }
        if (type.GetTypeInfo().IsGenericType)
        {
            if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return GetTypeName(Nullable.GetUnderlyingType(type)) + '?';
            }
            var genericTypeDefName = type.Name.Substring(0, type.Name.IndexOf('`'));
            var genericTypeArguments = string.Join(", ", type.GenericTypeArguments.Select(GetTypeName));
            if (type.GetTypeInfo().GetInterfaces().Any(ti => ti.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                return "collection";
            }
            return $"{genericTypeDefName}<{genericTypeArguments}>";
        }
        string typeName;
        if (_primitiveTypeNames.TryGetValue(type, out typeName))
        {
            return typeName;
        }
        // enum's come up as a ValueType so we check IsEnum first.
        if (type.GetTypeInfo().IsEnum)
        {
            return "enum";
        }
        if (type.GetTypeInfo().IsValueType)
        {
            return "struct";
        }
        return "object";
    }
    private static readonly Dictionary<Type, string> _primitiveTypeNames = new Dictionary<Type, string>
    {
        { typeof(bool), "bool" },
        { typeof(byte), "byte" },
        { typeof(byte[]), "byte[]" },
        { typeof(sbyte), "sbyte" },
        { typeof(short), "short" },
        { typeof(ushort), "ushort" },
        { typeof(int), "int" },
        { typeof(uint), "uint" },
        { typeof(long), "long" },
        { typeof(ulong), "ulong" },
        { typeof(char), "char" },
        { typeof(float), "float" },
        { typeof(double), "double" },
        { typeof(string), "string" },
        { typeof(decimal), "decimal" }
    };
}
