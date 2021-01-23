    public static void SetField<TObject, TProperty>(TObject obj, TProperty value)
    {
        typeof(TObject)
            .GetProperties()
            .Single(p => p.PropertyType == typeof(TProperty))
            .SetValue(obj, value);
    }
    var person = new Person();
    SetField(person, 123); // finds the only int property and sets its value
    SetField(person, FirstType.EnumValue); // find the only FirstType property
    SetField<Person, DateTime?>(person, DateTime.Now); // finds the only DateTime? property
