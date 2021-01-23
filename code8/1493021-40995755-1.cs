    //This is a extension class of enum
    public static string GetEnumDisplayName(this Enum enum)
    {
        return enum.GetType().GetMember(enum.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                       .Name;
    }
