    public object GenericMethod(object obj)
    {
        // modify the object in some (arbitrary) way
        IEnumerable<FieldInfo> fields = obj.GetType().GetRuntimeFields();
        foreach (var field in fields)
        {
            if (field.FieldType == typeof(string))
            {
                field.SetValue(obj, "This field's string value was modified");
            }
        }
        return obj;
    }
