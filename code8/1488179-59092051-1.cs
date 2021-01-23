    public static object GetPropValue(this object obj, Type typeName, string propName)
    {
        try
        {
            IList<PropertyInfo> props = new List<PropertyInfo>(typeName.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == propName)
                {
                    object propValue = prop.GetValue(obj, null);
                    return propValue;
                }
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("GetPropValue : " + ex.Message);
        }
        return null;
    }
