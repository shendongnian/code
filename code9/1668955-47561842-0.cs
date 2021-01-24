    public static void ConvertNullToStringEmpty<T>(this T clsObject) where T : class
    {
        PropertyInfo[] properties = clsObject.GetType().GetProperties();//typeof(T).GetProperties();
        foreach (var info in properties)
        {
            // if a string and null, set to String.Empty
            if (info.PropertyType == typeof(string) && info.GetValue(clsObject, null) == null)
            {
                info.SetValue(clsObject, String.Empty, null);
            }
        }
    }
