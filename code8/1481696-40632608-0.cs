    public static List<KeyValuePair> ClassToList(this object o)
    {
        Type type = o.GetType();
        List<KeyValuePair> vals = new List<KeyValuePair>();
        foreach (PropertyInfo property in type.GetProperties())
        {
            if (!property.PropertyType.Namespace.StartsWith("System.Collections.Generic"))
            {
                  vals.Add(new KeyValuePair(property.Name,(property.GetValue(o, null) == null ? "" : property.GetValue(o, null).ToString()))
            }
        }
        return sb.ToString();
    }
