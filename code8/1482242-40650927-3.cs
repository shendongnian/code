    public static void SetPersonField<T>(Person person, T value)
    {
        typeof (Person)
            .GetProperties()
            .Single(p => p.PropertyType == typeof(T))
            .SetValue(person, value);
    }
    // Usage (both are correct):
    SetPersonField(person, FirstType.EnumValue);
    SetPersonField<FirstType>(person, FirstType.EnumValue);
