    public static IEnumerable<Type> GetXmlIncludeTypes(Type type) {
        foreach (var attr in Attribute.GetCustomAttributes(type)) {
            if (attr is XmlIncludeAttribute) {
                yield return ((XmlIncludeAttribute)attr).Type;
            }
        }
    }
