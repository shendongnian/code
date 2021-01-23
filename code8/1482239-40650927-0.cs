    public void SetPersonField(Person person, Type personFieldType, object value)
    {
        typeof (Person)
            .GetProperties()
            .Single(p => p.PropertyType == personFieldType)
            .SetValue(person, value);
    }
