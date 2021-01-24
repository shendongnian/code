    void MyConvertFunction(Type type, string astring_toconvert)
    {
        var inst = Activator.CreateInstance(type); // create an instance of your class
        var prop = type.GetProperties().First(); // find the property we need to set
        var convertedValue = Convert.ChangeType(astring_toconvert, prop.PropertyType); // convert the string to the correct type, throwing an exception if can't convert
        prop.SetValue(inst, convertedValue);
        Debug.Log(inst);
    }
