    public static class TypeExensions
    {
        public static IEnumerable<Type> BaseTypeAsEnumerable(this Type type)
        {
            for (; null != type && type != typeof(object); type = type.BaseType)
                yield return type;
        }
    }
    public List<Type> FilterByGenericType(Type genericType)
    {
        return this._assemblies.SelectMany(x => x.GetTypes())
            .Where(fullType => fullType.BaseTypeAsEnumerable()
                                    .Where(type => type.IsGenericType)
                                    .Any(baseType => baseType.GetGenericTypeDefinition() == genericType))
            .ToList();
    }
