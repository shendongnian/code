    public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
    {
        var type = enumValue.GetType();
        var typeInfo = type.GetTypeInfo();
		var memberInfo = typeInfo.GetMember(enumValue.ToString());
        var attributes = memberInfo[0].GetCustomAttributes<TAttribute>();
        var attribute = attributes.FirstOrDefault();
        return attribute;
    }
