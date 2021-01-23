    public object GetEnumAttributeValue<TEnum>(TEnum value)
    {
        var enumAttribute = (EnumAttribute)typeof(TEnum)
            .GetCustomAttributes(typeof(EnumAttribute), false)
            .First();
        var valueAttribute = (EnumValueAttribute)typeof(TEnum).GetMember(value.ToString())
            .First()
            .GetCustomAttributes(typeof(EnumValueAttribute), false)
            .First();
        return Settings.Default[String.Format(enumAttribute.Key, valueAttribute.Id)];
    }
