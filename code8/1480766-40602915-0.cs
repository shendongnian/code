    public enum SupportedLanguages
    {
        [Description("sl-SL")]
        Sl,
        [Description("hr-HR")]
        Hr,
        [Description("ru-RU")]
        Ru
    }
    
    public static string GetDescription(this Enum value)
    {            
        FieldInfo field = value.GetType().GetField(value.ToString());
    
        DescriptionAttribute attribute
                = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    as DescriptionAttribute;
    
        return attribute == null ? value.ToString() : attribute.Description;
    }
