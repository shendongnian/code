    public static class TypeFiltres
    {
        public static IEnumerable<Type> WithMatchingInterface(this IEnumerable<Type> types)
        {
            return types.Where(type =>
                type.GetTypeInfo().GetInterface("I" + type.Name) != null);
        }
    }
