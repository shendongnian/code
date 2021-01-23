    //This is a extension class of enum
    public static string GetEnumDisplayName(this Enum enumType)
    {
        return enumType.GetType().GetMember(enumType.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                       .Name;
    }
