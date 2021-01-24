    internal object GetPropertyJSONValue(string prop)
    {
        object propValue = null;
    
        PropertyInfo info = this.GetType().GetProperty(prop, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (info != null)
        {
            propValue = info.GetValue(this, null);
    
            if (info.PropertyType.BaseType == typeof(Enum))
            {
                propValue = StringUtil.EnumToName((Enum)propValue);
            }
            else if (info.PropertyType.BaseType == typeof(Array))
            {
                if (propValue == null)
                {
                    propValue = new JArray();
                }
                else
                {
                    propValue = new JArray((Array)propValue);
                }
            }
        }
        return propValue;
    }
