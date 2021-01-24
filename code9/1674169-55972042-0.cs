    public static string GetDescription(this Enum value)
    {
        //pull out each value in case of flag enumeration
        var values = value.ToString().Split(',').Select(s => s.Trim());
        var type = value.GetType();
        return string.Join(" | ", values.Select(enumValue => type.GetMember(enumValue)
           .FirstOrDefault()
           ?.GetCustomAttribute<DescriptionAttribute>()
           ?.Description
           ?? enumValue.ToString()));
    }
