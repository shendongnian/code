    // taken from /a/32193206
    public static string GetDisplayName(this Enum enum)
    {
        Type enumType = enumeration.GetType();
        string enumName = Enum.GetName(enumType, enumeration);
        string displayName = enumName;
        try
        {
            MemberInfo member = enumType.GetMember(enumName)[0];
    
            object[] attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            DisplayAttribute attribute = (DisplayAttribute)attributes[0];
            displayName = attribute.Name;
    
            if (attribute.ResourceType != null)
            {
                displayName = attribute.GetName();
            }
        }
        catch (Exception e) { }
        return displayName;
    }
