    public static TAttribute GetAttributeOrUseMetadata<TAttribute>(this PropertyInfo element, bool inherit = false) where TAttribute : System.Attribute
    {
        //Find normal attribute
        var attribute = element.GetCustomAttribute<TAttribute>(inherit);
        if (attribute != null)
        {
            return attribute;
        }
        //Find via MetadataTypeAttribute
        if (element.DeclaringType != null)
        {
            var metadataType = element.DeclaringType.GetCustomAttribute<MetadataTypeAttribute>(inherit);
            var metadataPropertyInfo = metadataType?.MetadataClassType.GetProperty(element.Name);
            return metadataPropertyInfo?.GetCustomAttribute<TAttribute>();
        }
        return null;
    }
