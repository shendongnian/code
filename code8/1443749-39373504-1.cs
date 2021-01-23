    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var jsonProperty = base.CreateProperty(member, memberSerialization);
        if (jsonProperty.ObjectCreationHandling == null && jsonProperty.PropertyType.GetListType() != null)
            jsonProperty.ObjectCreationHandling = ObjectCreationHandling.Replace;
        return jsonProperty;
    }
    public static class TypeExtensions
    {
        public static Type GetListType(this Type type)
        {
             while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();
                    if (genType == typeof(List<>))
                        return type.GetGenericArguments()[0];
                }
                type = type.BaseType;
            }
            return null;
        }
    }
