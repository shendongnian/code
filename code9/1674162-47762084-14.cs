    public static string GetEnumDescription(Enum value)
    {
        String valueText = value.ToString();
        Type type = value.GetType();
        FieldInfo fi = type.GetField(valueText);
        Object[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
        if (attributes.Length > 0)
        {
            DescriptionAttribute attribute = (DescriptionAttribute)attributes[0];
            return attribute.Description;
        }
    
        return valueText;
    }
