    public static void SetPrivatePropertyValue<T>(T obj, string propertyName, object newValue)
    {
        // add a check here that the object obj and propertyName string are not null
        foreach (FieldInfo fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            if (fi.Name.ToLower().Contains(propertyName.ToLower()))
            {
                fi.SetValue(obj, newValue);
                break;
            }
        }
    }
