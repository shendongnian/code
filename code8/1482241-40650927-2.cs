    public static void SetPersonField<T>(Person person, T value)
    {
        typeof (Person)
            .GetProperties()
            .Single(p => p.PropertyType == typeof(T))
            .SetValue(person, value);
    }
    // Usage:
    SetPersonField(person, FirstType.EnumValue);
