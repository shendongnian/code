    static private List<Type> AttributeFilter(IEnumerable<XmlIncludeAttribute> attributes, Type baseType)
    {
        List<Type> filteredAttributes = new List<Type>();
        foreach (XmlIncludeAttribute at in attributes)
        {
            if (at.Type.BaseType == baseType)
            {
                filteredAttributes.Add(at.Type);
            }
        }
        return filteredAttributes;
    }
