    var property = obj.GetType().GetProperty("XYZ");
    var value = property.GetValue(obj);
    switch (value)
    {
        case Boolean b:
            ...
        ...
    }
