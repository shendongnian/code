    public static string GetName(this myEnum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .GetCustomAttribute<DisplayAttribute>()
                        .GetName();
    }
