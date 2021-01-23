    private static T GetValueFromEnumMember<T>(string value)
    {
        var type = typeof(T);
        if (type.GetTypeInfo().IsEnum)
        {
            foreach (var name in Enum.GetNames(type))
            {
                var attr = type.GetRuntimeField(name).GetCustomAttribute<EnumMemberAttribute>(true);
                if (attr != null && attr.Value == value)
                    return (T)Enum.Parse(type, name);
            }
    
            return default(T);
        }
    
        throw new InvalidOperationException("Not Enum");
     }
